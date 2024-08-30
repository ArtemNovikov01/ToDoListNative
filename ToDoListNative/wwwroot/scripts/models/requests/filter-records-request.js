class FilterRecordsRequest {
    constructor(search = null, skip = 0, count = 0, isComplete = null) {
        this.search = search;
        this.skip = skip;
        this.count = count;
        this.isComplete = isComplete;
    }
}