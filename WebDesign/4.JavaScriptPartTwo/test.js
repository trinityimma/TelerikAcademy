;(function() {
    'use strict';

    function Person(firstName, middleName, lastName) {
        this.firstName = firstName
        this.middleName = middleName
        this.lastName = lastName
    }

    Person.prototype.toString = function() {
        var info = []

        info.push('First name: ' + this.firstName)
        info.push('Middle name: ' + this.middleName)
        info.push('Last name: ' + this.lastName)

        return info.join('\n')
    }

    console.log(new Person('Pesho', 'Ivanov', 'Ivanov').toString())
}())
