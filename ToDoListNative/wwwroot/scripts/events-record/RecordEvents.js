async function RecordModalBuild(id) {
    const html = `<div class="container-fluid" style="font-size: 1.0rem;">
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
                                          <div id='containerChekBoxInput'></div>
                                              <button id="SaveRecordButton" class="btn btn-primary btn-lg">Сохранить</button>
                                          </div>
                                      </form>
                                  </div>
                              </div>
                          </div>
                      </div>`;
    if (id === 0) {
        const container = document.querySelector('.modal-body.overflow-auto');
        container.innerHTML = html;

        const button = document.getElementById("SaveRecordButton");
        button.addEventListener('click', async (event) => {
            event.preventDefault();
            var title = document.getElementById("RecordTitle").value;
            var content = document.getElementById("RecordContent").value;
            let record = await createRecord(title, content);

            let recordInfo = new RecordShortModels(record.id, record.title, record.status)
            RenderRow(recordInfo);
            modal.hide();
        });

        const modal = new bootstrap.Modal(document.getElementById('form-modal-record'));
        modal.show();
    }
    else {
        let recordResponse = await getRecord(id);

        let record = new GetRecordInfoResponse(recordResponse.id, recordResponse.title, recordResponse.content, recordResponse.isComplete)
        const container = document.querySelector('.modal-body.overflow-auto');
        container.innerHTML = html;

        var containerCheckBox = document.getElementById('containerChekBoxInput');
        const checkbox = document.createElement('input');
        checkbox.setAttribute('id','statusCheckBox');
        checkbox.type = 'checkbox';
        checkbox.checked = record.isComplete;
        containerCheckBox.appendChild(checkbox);

        var title = document.getElementById("RecordTitle");
        var content = document.getElementById("RecordContent");
        var isComplete = document.getElementById("statusCheckBox");

        title.value = record.title
        content.value = record.content
        
        //ToDo Разобраться почему не меняется checkbox
        const button = document.getElementById("SaveRecordButton");
        button.addEventListener('click', async (event) => {
            event.preventDefault();
            await updateRecord(id, title.value, content.value, isComplete.);

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
    const table = document.querySelector('table');

    // Получаем количество всех строк в таблице
    const rowCount = table.rows.length;

    const row = document.createElement('tr');

    // ID (скрытая)
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
    numberCell.textContent = rowCount;
    row.appendChild(numberCell);

    // заголовок
    const titleCell = document.createElement('td');
    titleCell.textContent = record.title;
    row.appendChild(titleCell);

    tableBody.appendChild(row);
}
