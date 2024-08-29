async function getRecords(search, skip, count) {
    const request = new FilterRecordsRequest(search, skip, count);
    const response = await fetch("api/record/getRecords", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(request)
    });

    if (response.ok) {
        return await response.json();
    } else {
        console.error("Ошибка при получении записей:", response.statusText);
        return [];
    }
}

async function getRecord(id) {
    const response = await fetch("api/record/getRecord?id="+id, {
        method: "GET",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
    });

    if (response.ok) {
        return await response.json();
    } else {
        console.error("Ошибка при получении записи:", response.statusText);
        return [];
    }
}

async function createRecord(title, content) {
    const request = new CreateRecordRequest(title, content);
    const response = await fetch("api/record/createRecord", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(request)
    });

    if (response.ok) {
        return await response.json();
    } else {
        console.error("Ошибка создании записи:", response.statusText);
    }
}
async function updateRecord(id, title, content, status) {
    const request = new UpdateRecordRequest(id, title, content, status);
    const response = await fetch("api/record/updateRecord", {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(request)
    });
    if (response.ok) {
        return await response.json();
    } else {
        console.error("Ошибка обновления записи:", response.statusText);
    }
}

async function statusChangeRecord(id, status) {
    const request = new ChangeStatusRecordRequest(id, status);
    const response = await fetch("api/record/statusChangeRecord", {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(request)
    });
}

async function deleteRecord(id) {
    const response = await fetch("api/record/deleteRecord?id="+id, {
        method: "DELETE",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
    });
}

//ToDo Перенести в отдельный файл
class FilterRecordsRequest {
    constructor(search = null, skip = 0, count = 0) {
        this.search = search;
        this.skip = skip;
        this.count = count;
    }
}
