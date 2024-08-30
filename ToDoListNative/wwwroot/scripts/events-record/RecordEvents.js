async function RecordModalBuild(id) {
    const html = `
        <div class="container-fluid" style="font-size: 1.0rem;">
            <div class="col-12">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <form class="needs-validation" method="post" enctype="multipart/form-data" novalidate>
                            <div class="row mb-3">
                                <div class="col-12">
                                    <label class="form-label">Название</label>
                                    <input id="RecordTitle" class="form-control" required />
                                    <div class="invalid-feedback">Пожалуйста, введите название.</div>
                                </div>
                            </div>
                            <div class="row mb-3">
                                <div class="col-12">
                                    <label class="form-label">Описание</label>
                                    <textarea id="RecordContent" class="form-control" rows="3" required></textarea>
                                    <div class="invalid-feedback">Пожалуйста, введите описание.</div>
                                </div>
                            </div>
                            <div class="text-end">
                            <p id="errorMessage" style="color:red"></p>
                                <div id="containerCheckBoxInput"></div>
                                <button id="SaveRecordButton" class="btn btn-primary btn-lg">Сохранить</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>`;

    const container = document.querySelector('.modal-body.overflow-auto');
    container.innerHTML = html;

    if (id === 0) {
        // Код для добавления новой записи
        const button = document.getElementById("SaveRecordButton");

        const errorMessage = document.getElementById("errorMessage");

        var title = document.getElementById("RecordTitle");

        if (title.value === "" || title.value === null) {
            button.disabled = true;
            errorMessage.innerHTML = "Поле заголовок должно быть заполнено";
        }

        title.addEventListener('input', (event) => {
            if (title.value.length > 0) {
                console.log("asdasd")
                button.disabled = false;
                errorMessage.innerHTML = "";
            }
            else {
                button.disabled = true;
                errorMessage.innerHTML = "Поле заголовок должно быть заполнено";
            }
        });

        button.addEventListener('click', async (event) => {
            event.preventDefault();

            var content = document.getElementById("RecordContent").value;
            let record = await createRecord(title.value, content);

            let recordInfo = new RecordShortModels(record.id, record.number, record.title, record.status);
            RenderRow(recordInfo);
            modal.hide();
        });

        const modal = new bootstrap.Modal(document.getElementById('form-modal-record'));
        modal.show();
    } else {
        // Код для редактирования существующей записи
        let recordResponse = await getRecord(id);
        let record = new GetRecordInfoResponse(recordResponse.id, recordResponse.title, recordResponse.content, recordResponse.isComplete);

        // Инициализация элементов
        var title = document.getElementById("RecordTitle");
        var content = document.getElementById("RecordContent");
        title.value = record.title;
        content.value = record.content;

        const button = document.getElementById("SaveRecordButton");
        button.addEventListener('click', async (event) => {
            event.preventDefault();

            await updateRecord(id, title.value, content.value);

            modal.hide();

            let tableBody = document.querySelector('.table tbody');
            tableBody.innerHTML = '';
            Render();
        });

        const modal = new bootstrap.Modal(document.getElementById('form-modal-record'));
        modal.show();
    }
}


function RenderRow(record) {

    let tableBody = document.querySelector('.table tbody');

    const row = document.createElement('tr');

    // Id (скрытая)
    const idCell = document.createElement('td');
    idCell.textContent = record.id;
    idCell.classList.add('hidden');
    row.appendChild(idCell);

    // статус (скрыт)
    const statusCell = document.createElement('td');
    statusCell.textContent = record.status;
    statusCell.classList.add('hidden');
    row.appendChild(statusCell);

    // чекбокс
    const checkboxCell = document.createElement('td');
    const checkbox = document.createElement('input');
    checkbox.type = 'checkbox';
    checkbox.checked = record.status;

    checkboxCell.appendChild(checkbox);
    checkbox.addEventListener('click', (event) => {
        statusChangeRecord(record.id, !record.status);
    });

    row.appendChild(checkboxCell);

    // номер
    const numberCell = document.createElement('td');
    numberCell.textContent = record.number;
    row.appendChild(numberCell);

    // заголовок
    const titleCell = document.createElement('td');
    titleCell.textContent = record.title;
    row.appendChild(titleCell);

    // кнопка просмотра
    const viewCell = document.createElement('td');
    const viewButton = document.createElement('button');
    viewButton.textContent = 'Смотреть';
    viewButton.className = 'btn btn-secondary btn-lg';
    viewButton.style = 'font-size:small';

    viewCell.appendChild(viewButton);
    viewButton.addEventListener('click', (event) => {
        event.preventDefault();
        RecordModalBuild(record.id);
    });
    row.appendChild(viewCell);

    // кнопка удаления
    const deleteCell = document.createElement('td');
    const deleteButton = document.createElement('button');
    deleteButton.textContent = 'Удалить';
    deleteButton.className = 'btn btn-danger btn-lg';
    deleteButton.style = 'font-size:small';

    deleteCell.appendChild(deleteButton);
    deleteButton.addEventListener('click', async (event) => {
        event.preventDefault();
        await deleteRecord(record.id);
        row.remove();
    });
    row.appendChild(deleteCell);

    tableBody.appendChild(row);
}
