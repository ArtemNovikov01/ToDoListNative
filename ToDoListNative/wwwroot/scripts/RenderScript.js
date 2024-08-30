async function Render(search = null, skip = 0, count = 10, isComplete = null) {

    let tableBody = document.querySelector('.table tbody');
    let totalCountCell = document.getElementById('totalCount');
    tableBody.innerHTML = '';

    var arrayRecords = await getRecords(search, skip, count, isComplete);
    const mappedRecords = arrayRecords.records.map(record => new RecordShortModels(record.id, record.number, record.title, record.status));

    mappedRecords.forEach((record, index) => {
        const row = document.createElement('tr');

        totalCountCell.innerText = arrayRecords.totalCount;
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
        checkbox.addEventListener('click', () => {
            statusChangeRecord(record.id, checkbox.checked);
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
            let count = arrayRecords.totalCount - 1
            totalCountCell.innerText = count;
        });
        row.appendChild(deleteCell);

        tableBody.appendChild(row);
    });
}
