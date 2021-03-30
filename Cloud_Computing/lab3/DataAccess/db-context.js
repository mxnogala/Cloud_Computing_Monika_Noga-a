const sql = require('mssql');
const parser = require('mssql-connection-string');

class PeopleDbContext {
    constructor(connectionString, log) {
        log("PeopleDbContext object has been created.");
        this.log = log;
        this.config = parser(connectionString);
        this.getPeople = this.getPeople.bind(this);
    }

    async getPeople() {
        this.log("getPeople function - run")
        const connection = await new sql.ConnectionPool(this.config).connect();
        const request = new sql.Request(connection);
        const result = await request.query('select * from People');
        this.log("getPeople function - done")
        return result.recordset;
    }

    async getPerson(id) {
        const connection = await new sql.ConnectionPool(this.config).connect();
        const request = new sql.Request(connection);
        const query = 'select * from People where PersonId =' + id;
        this.log(query);
        const result = await request.query(query);
        return result.recordset;
    }

    async createPerson(name, surname, phone) {
        const connection = await new sql.ConnectionPool(this.config).connect();
        const request = new sql.Request(connection);
        const query = `insert into People values ('` + name + `','` + surname + `','` + phone + `')`;
        this.log(query);
        const result = await request.query(query);
        return result.recordset;
    }

    async deletePerson(id) {
        const connection = await new sql.ConnectionPool(this.config).connect();
        const request = new sql.Request(connection);
        const query = `delete from People where PersonId = ` + id;
        this.log(query);
        const result = await request.query(query);
        return result.recordset;
    }
}

module.exports = PeopleDbContext;