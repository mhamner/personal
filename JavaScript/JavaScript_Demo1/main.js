//alert('Hi there!');

//Regualar comment

/* Multi-line
comment 
demo
*/

console.log('hi there!');
console.error('This is an error message');
console.warn('This is a warning message');
console.info('This is an informational message');

//variable demos
let i = 1;
i = 2;
console.log(i);
const c = 10;
console.log(c);

//Data Type demos
const userName = 'Mark';    //Creates a string
const age = 30;             //Creates a number
const isComplete = false;   //Creates a boolean
const x = null;             //Creates a null
const y = undefined;        //Creates an undefined
let z;                      //Also creates an undefined
console.log(typeof userName);
console.log(typeof age);
console.log(typeof isComplete);
console.log(typeof x);      //Note:  Null will return type of object - this is incorrect - see Note in Note Set
console.log(typeof y);
console.log(typeof z);

//String concatenation demo
const greeting1 = 'Hello ' + userName + ' and welcome to Waystar!';
const greeting2 = `Hello ${userName} and welcome to Waystar!`;      //Note that this uses 'back ticks' - the thing on the number row at the far left under the ~
console.log(greeting1);
console.log(greeting2);

//Some cool string properties and methods
const a = 'Waystar';
console.log(a.length);
console.log(a.toLowerCase());
console.log(a.toUpperCase());
console.log(a.split(''));
const l = 'one, two, three, four';
console.log(l.split(', '));

//Arrays demo
const numbers = new Array(1,2,3,4);
const companies = ['Waystar','Humana','Appriss','Yum!',true,5];
console.log(numbers);
console.log(companies);
console.log(companies[0]);      //Writes out the first company in the array
companies.push('RSCS');         //Adds to the end of the array
console.log(companies);     
companies.unshift('GE');        //Adds to the beginning of the array
console.log(companies);
companies.pop();                //Removes the last item from the array
console.log(companies);
console.log(Array.isArray(companies));  //Says whether an item is an array or not
console.log(companies.indexOf('Humana'));

//Object literals demo
const person = {
    firstName: 'Mark',
    lastName: 'Hamner',
    employer: 'Waystar',
    hobbies: ['nerd stuff', 'more nerd stuff', 'even more nerd stuff'],
    address:    {
        street: '123 Main Street',
        city: 'Louisville',
        state: 'KY',
        zip: '40241'
    }
}
console.log(person);
console.log(person.firstName, person.lastName);
console.log(person.hobbies);
console.log(person.hobbies[1]);     //Show the second hobby in my hobbies array (0,1,2)
console.log(person.address.city);
//Object destructuring example
const {firstName, lastName} = person;
console.log(firstName);     //See, now you can reference firstName and lastName directly as variables
console.log(lastName);
const {address: { city }} = person;     //This is how you destructure an embedded object - see how we pull address.city out
console.log(city);
//You can add properties to the object on the fly
person.email = 'mark.hamner@waystar.com';
console.log(person.email);

//Arrays of objects demo
const toDoList = [
    {
        id: 1,
        text: 'Write some awesome code',
        isCompleted: true
    },
    {
        id: 2,
        text: 'Go to some meetings',
        isCompleted: false
    },
    {
        id: 3,
        text: 'Drink more coffee',
        isCompleted: false
    }
];
console.log(toDoList);
console.log(toDoList[1].text);      //Show the 'text' property of the second item (index 1) in the array

//JSON Demo
const toDoListJSON = JSON.stringify(toDoList);      //Convert our To Do List array of objects to JSON using JSON.stringify
console.log(toDoListJSON);

//For loop demo
for(let i = 0; i < 10; i++)
{
    console.log(`For Loop Iteration Number: ${i}`);
}

//While loop demo
let j = 0;
while(j < 10)
{
    console.log(`While Loop Iteration Number: ${j}`);
    j++;
}

//Demo of looping through an array of objects
for(let a = 0; a < toDoList.length; a++)
{
    console.log(`To Do Item:  ${toDoList[a].text}`);
}

//Demo of looping through an array of objects using Javascript's equivalent of C#'s "foreach item of items"
for(let toDo of toDoList)
{
    console.log(`To Do Item: ${toDo.text}`);
}

//Demo of looping through an array of objects using the array's high order .forEach method
toDoList.forEach(function(toDo)
{
    console.log(`To Do Item: ${toDo.text}`);
});

//Demo of looping through our existing array and using .map to create a new array containing only the fields you "return"
const toDoText = toDoList.map(function (todo)
{
    return todo.text;
});
toDoText.forEach(function(tdt)
{
    console.log(`ToDo Text Array Member: ${tdt}`);
});

//Demo of creating a new array using .filter.  New array will contain only the items that match the filter criteria you specify.
const toDoFiltered = toDoList.filter(function(todo)
{
    return todo.isCompleted == true;
});
console.log(toDoFiltered);      //Show all the properties for the filtered members
toDoFiltered.forEach(function(tdf)
{
    console.log(`ToDo Array Filtered Member: ${tdf.text}`);     //Show only the .text for the filtered members
});

//Demo of combining .filter and .map to get an array of only the completed items AND only the .text property
const toDoFilteredandMapped = toDoList.filter(function(todo)
{
    return todo.isCompleted == true;
}).map(function(todo)
{
    return todo.text;
});
console.log(toDoFilteredandMapped);      

//Demo of if statements and how == and === differ
const k = '10';
//Double equals == only compares the VALUES, so comparing 10 (numeric) and '10' (string) would return true
if(k == 10)
{
    console.log('comparison returned true');
}
else
{
    console.log('comparison returned false');
}
//Tripe equals === compares both the values AND the data type, so comparing 10 (numeric) and '10' (string) would return false
if(k === 10)
{
    console.log('comparison returned true');
}
else
{
    console.log('comparison returned false');
}

//Demoing else if and else some more
if(k === 10)
{
    console.log('k is equal to 10');
}
else if (k > 10)
{
    console.log('k is greater than 10');
}
else
{
    console.log('k is not greater than 10 or equal to 10 or the data types do not match');
}

//Demoing OR using double pipes ||
const ab = 10;
const bc = 20;
if(ab === 10 || bc ===11)
{
    console.log('One condition was met');
}

//Demoing AND using double ampersands &&
if(ab === 10 && bc ===11)
{
    console.log('Both conditions were met');
}

//Demoing using ternary operators to assign values based on conditions
const grade = 95;
const goodOrBad = grade > 90 ? 'good' : 'bad';
console.log(goodOrBad);

//Demoing the switch statement using the good or bad variable above
switch(goodOrBad)
{
    case 'good':
        console.log('You have done well. - Emperor Palpatine');
        break;
    case 'bad':
        console.log('Much to learn you still have. - Yoda');
        break;
    default:
        console.log('I sense a great disturbance in the Force.');
        break;
}

//Demoing functions
function determineLetterGrade(grade1, grade2)
{
    const gradeAverage = (grade1 + grade2)/2;
    //Notice the ORDER of the "case" statements are very important here!  If you did, say, 'D', first, then a 95 would get a D because 95 >= 60!
    switch(true)
    {
        case (gradeAverage >= 90):
            console.log('You got an A!');
            break;
        case (gradeAverage >= 80):
            console.log('You got a B!');
            break;
        case (gradeAverage >= 70):
            console.log('You got a C.');
            break;
        case (gradeAverage >= 60):
            console.log('You got a D.');
            break;
        case (gradeAverage < 60):
            console.log('Do better next time.');
            break;
        default:
            console.log('Unable to determine grade');
            break; 
    }
}
determineLetterGrade(80,90);

//Using return in functions
function addNumbers(num1, num2)
{
    return num1 + num2;
}
console.log(addNumbers(5,4));

//Arrow functions
const addNums = (num1, num2) => num1 + num2;
console.log(addNums(3,2));
const addNum2 = (num1, num2) => 
{ 
    return (num1 + num2); 
};
console.log(addNum2(5,1));

//Using arrow functions to log our earlier To Do List
toDoList.forEach((todo) => console.log(todo));

//Constructor functions in Javascript
function Avenger(firstName, lastName, dob)
{
    this.firstName = firstName;
    this.lastName = lastName;
    this.dob = new Date(dob);   //Creates a new date object and converts dob to a date
}
//Instantiate the object
const avenger1 = new Avenger('Tony','Stark','05-29-1970');
console.log(avenger1);
console.log(`First Name is ${avenger1.firstName}`);

//Demoing creating methods within your object
function Student(firstName, lastName, dob)
{
    this.firstName = firstName;
    this.lastName = lastName;
    this.dob = new Date(dob);   
    this.getBirthYear = () => this.dob.getFullYear();   //Fat arrow method to uses date functions to return the birth year
    this.getFullName = () => `${this.firstName} ${this.lastName}`;      //Fat arrow method that returns the concatenated name
    this.getLengthofFullName = function()
    {
        const length = (this.firstName.length + this.lastName.length);
        return length;
    }
}
//Instantiate the object
const student1 = new Student('Zack','Morrison','11-04-1980');
console.log(student1);
console.log(`First Name is ${student1.firstName}`);
console.log(student1.getBirthYear());
console.log(student1.getFullName());
console.log(student1.getLengthofFullName());

//Demoing prototypes
function Teacher(firstName, lastName, dob)
{
    this.firstName = firstName;
    this.lastName = lastName;
    this.dob = new Date(dob);   
    this.getBirthYear = () => this.dob.getFullYear();   //Fat arrow method to uses date functions to return the birth year
    this.getFullName = () => `${this.firstName} ${this.lastName}`;      //Fat arrow method that returns the concatenated name
}
Teacher.prototype.getLengthofFullName = function()
{
    const length = (this.firstName.length + this.lastName.length);
    return length;
}
//Instantiate the object
const teacher1 = new Teacher('Richard','Belding','11-04-1965');
console.log(teacher1);
console.log(`First Name is ${teacher1.firstName}`);
console.log(teacher1.getLengthofFullName());

//Demoing Classes
class Person
{
    constructor(firstName, lastName, dob)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.dob = new Date(dob)
    }

    getBirthYear()
    {
        return this.dob.getFullYear();
    }

    getFullName()
    {
        return `${this.firstName} ${this.lastName}`;
    }
}
const person1 = new Person("Peter","Parker",'10-15-1991');
console.log(`Name is ${person1.getFullName()}.`);
console.log(`This person was born in the year ${person1.getBirthYear()}.`);

