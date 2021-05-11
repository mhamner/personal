//Single element selectors
/*
const form = document.getElementById('my-form');
console.log(form);

console.log(document.querySelector('h1'));

//Multiple element selectors
console.log(document.querySelectorAll('.item'));
console.log(document.getElementsByClassName('item'));
console.log(document.getElementsByTagName('li'));

//Loop through items
const items = document.querySelectorAll('.item');
console.log(items);
items.forEach((item) => console.log(item));

//Remove items from the UL
const myUl = document.querySelector('.items');
//myUl.remove();    //Remove the document element stored in the "ul" const
myUl.lastElementChild.remove();

//Change the text of the first item in the UL
myUl.firstElementChild.textContent = 'Hello there!';

//Change the text of the second item in the UL
myUl.children[1].innerText = 'General Kenobi!';

//Add HTML to the last item in the UL
myUl.lastElementChild.innerHTML = '<h4>Attack of the Clones</h4>';

//Change the color of our submit button to red
const btn = document.querySelector('.btn');     //Get the button from our UI into a const
btn.style.background = 'red';

//Demoing adding an Event Listener and running an arrow => function
const btn2 = document.querySelector('.btn');
btn2.addEventListener('click', (e) => 
{ 
    e.preventDefault(); //Stop the page from refreshing
    console.log('User clicked the button.');
})

//Demoing adding an Event Listener and running a function we created separately
const btn3 = document.querySelector('.btn');
btn3.addEventListener('click', ShowClickedMessage);

function ShowClickedMessage(e)
{
    e.preventDefault();
    console.log('User clicked the button.');
    console.log(e.target);
}

const btn4 = document.querySelector('.btn');
btn4.addEventListener('click', ChangeBackground);

function ChangeBackground(e)
{
    e.preventDefault();
    document.querySelector('#my-form').style.background = "#ccc";
}

const btn5 = document.querySelector('.btn');
btn5.addEventListener('click', ChangeBodyBackground);

function ChangeBodyBackground(e)
{
    e.preventDefault();
    document.querySelector('body').classList.add('bg-dark');
}

const btn6 = document.querySelector('.btn');
btn6.addEventListener('click', AddHtmlToUl);

function AddHtmlToUl(e)
{
    e.preventDefault();
    document.querySelector('.items').lastElementChild.innerHTML = '<h1>Return of the Jedi</h1>';
}

const btn7 = document.querySelector('.btn');
btn7.addEventListener('mouseover', AddHoverMessageToUl);
btn7.addEventListener('mouseout', AddMouseOutMessageToUl);

function AddHoverMessageToUl(e)
{
    e.preventDefault();
    document.querySelector('.items').firstElementChild.innerHTML = '<h1>Stop Hovering!</h1>';
}
function AddMouseOutMessageToUl(e)
{
    e.preventDefault();
    document.querySelector('.items').firstElementChild.innerHTML = '<h1>Much better.</h1>';
}

*/
//Demoing listening for submit event on the form.  NOTE:  Comment out all the stuff above before showing this, as the prevent default stuff on the hover and mouseout
//  will stop this from working
const myForm = document.querySelector('#my-form');
const nameInput = document.querySelector('#name');
const emailInput = document.querySelector('#email');
const msg = document.querySelector('.msg');
const userList = document.querySelector('#users');
myForm.addEventListener('submit', onSubmit);

function onSubmit(e)
{
    e.preventDefault();

    if(nameInput.value === '' || emailInput.value === '')
    {
        //alert('Please enter a value for both name and email.');
        msg.classList.add('error');     //Associate our .css error class with the msg const
        msg.innerHTML = 'Please enter a value for both name and email.';

        setTimeout(() => 
        {
            msg.innerHTML = '';
            msg.classList.remove('error');
        }, 3000);   //Remove msg after 3 seconds
    }
    else
    {
        console.log('Submit event detected!');
        console.log(`Name entered is: ${nameInput.value}`);
        console.log(`Email entered is: ${emailInput.value}`);

        const li = document.createElement('li');
        li.appendChild(document.createTextNode(`${nameInput.value} - ${emailInput.value}`));
        userList.appendChild(li);

        nameInput.value = '';
        emailInput.value = '';
    }
   
}
