async function Render() {
    let tableBody = document.querySelector('.table tbody');
    tableBody.innerHTML = '';

    var arrayRecords = await getRecords(null, 1, 10);
    const mappedRecords = arrayRecords.records.map(record => new RecordShortModels(record.id, record.title, record.status));

    mappedRecords.forEach((record, index) => {
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
        numberCell.textContent = index + 1;
        row.appendChild(numberCell);

        // заголовок
        const titleCell = document.createElement('td');
        titleCell.textContent = record.title;
        row.appendChild(titleCell);

        const deleteCell = document.createElement('td');
        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Смотреть';
        deleteButton.className = 'btn btn-secondary btn-lg';
        deleteButton.style = 'font-size:small';

        deleteCell.appendChild(deleteButton);
        deleteButton.addEventListener('click', (event) => {
            event.preventDefault(); 
            RecordModalBuild(record.id);
        });
        row.appendChild(deleteCell);

        tableBody.appendChild(row);
    });
}
