
function runWhenLoaded() {

    const x = 12;
    const y = "12";

    if(x == y) {
        alert("x == y");
    } else {
        alert("x != y");
    }

    if(x === y) {
        alert("x === y");
    } else {
        alert("x !== y");
    }

}

function testEmbeddedQuotes() {

    const insideString = "[this is inside the other string.]"

    const a = "here is text\n" + insideString + "\nthis is different text on a new line\nthis is more text on a new line";
    const b = `here is text
${insideString}
this is text on a new line
this is more text on a new line`;

    writeEqualityToConsole(a, b);

}

function writeEqualityToConsole(x, y) {

    console.log("x: " + x);
    console.log("y: " + y);

    if(x == y) {
        console.log("x == y");
    } else {
        console.error("x != y");
    }

    if(x === y) {
        console.log("x === y");
    } else {
        console.warn("x !== y");
    }
}

function arrayTest() {
    const daysPerWeek = 7;  //declares a variable which value cannot be changed    
    console.log(`There are ${daysPerWeek} days in the week.`);

    let daysPerMonth = 30;  //declres a variable where value can be changed
    console.log(`There are ${daysPerMonth} days in the month.`);

    const weekdays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
    console.table(weekdays);

    let buildWeekdays = [];
    while(weekdays.length > 0) {
        const theWeekday = weekdays.pop();
        buildWeekdays.push(theWeekday);

        console.log("Counts: ", weekdays.length, buildWeekdays.length);

    }

    console.table(weekdays);
    console.table(buildWeekdays);
}

function objectTest() {
    const person = {
        firstName: "Bill",
        lastName: "Lumbergh",
        age: "42",
        employees: [
            "Peter Gibbons",
            "Milton Waddams",
            "Samir Nagheenanajar",
            "Michael Bolton"
        ],
        formatName: function() {
            return `${this.lastName}, ${this.firstName}`;
        },
        toString: function() {
            return `${this.formatName} (${this.age})`;
        }
    };

    // person.age = Number(person.age);
    // console.log("person.age === 42: ", person.age === 42);

    // console.table(person);
    // console.log(`${person.firstName} ${person.lastName}`);
    // console.log(person.formatName());
    // console.table(person.employees);

    for(let i = 0; i < person.employees.length; i++) {
        console.log(`Employee ${i + 1} is ${person.employees[i]}.`);
    }

}


function testFunctions() {
    const result1 = square(5);
    const result2 = square(2);

    console.log("result1: ", result1);
    console.log("result2: ", result2);
    

}

function square(value) {
    return Math.pow(value, 3);
}


/*
########################
Function Overloading
########################
 
Function Overloading is not available in Javascript. If you declare a 
function with the same name, more than one time in a script file, the 
earlier ones are overriden and the most recent one will be used. 
*/

function Add(num1, num2) {
    return num1 + num2;
}

function Add(num1, num2, num3) {
    return num1 + num2 + num3;
}

/* 
########################
Math Library
########################
 
A built-in `Math` object has properties and methods for mathematical constants and functions.
*/

function mathFunctions() {
    console.log("Math.PI : " + Math.PI);
    console.log("Math.LOG10E : " + Math.LOG10E);
    console.log("Math.abs(-10) : " + Math.abs(-10));
    console.log("Math.floor(1.99) : " + Math.floor(1.99));
    console.log("Math.ceil(1.01) : " + Math.ceil(1.01));
    console.log("Math.random() : " + Math.random());
}


/*
########################
String Methods
########################

The string data type has a lot of properties and methods similar to strings in Java/C#
*/

function stringFunctions(value) {
    console.log("Value: ", value);
    console.log(`.length -  ${value.length}`)
    console.log(`.endsWith('World') - ${value.endsWith('World')}`);
    console.log(`.startsWith('Hello') - ${value.startsWith('Hello')}`);
    console.log(`.indexOf('Hello') - ${value.indexOf('Hello')}`);

    /*
    Other Methods
        - split(string)
        - substr(number, number)
        - substring(number, number)
        - toLowerCase()
        - trim()
        - https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String
    */
}


function checkStrings() {
    stringFunctions("Something");
    stringFunctions("Hello Something");
    stringFunctions("Something Hello");
    stringFunctions("Something Hello Something");
}





const numbers = [-10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

// Other Array Functions
// using Arrow Operators
function filterFunctions() {     
                        
    // Filter accepts a single argument indicating the element in the array
    const oddNumbers = numbers.filter(number => Math.abs(number % 2) == 1);
    console.table(oddNumbers);

    const evenNumbers = numbers.filter(number => number % 2 == 0);
    console.table(evenNumbers);
    
    const evenPositives = numbers.filter(number => number % 2 == 0 && number > 0);
    console.table(evenPositives);    
}


