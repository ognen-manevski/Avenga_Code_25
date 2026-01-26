function SwapiPeopleResponse(total, next, previous, results) {
    this.total = total;
    this.nextPage = next;
    this.previousPage = previous;
    this.results = results;

    this.hasNextPage = function() {
        return this.nextPage !== null;
    }
    this.hasPreviousPage = function() {
        return this.previousPage !== null;
    }
    this.getPeopleByName = function(name) {
        for (let person of this.results) {
            if (person.name === name) {
                return person;
            }
        }
        return null;
    }
}
