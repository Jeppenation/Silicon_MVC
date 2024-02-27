

const compareValidator = (value, compareElement) => {
    if (value !== compareElement.value) {
        return false;
    }
    return true;
}



const textValidator = (element, minLength = 2) => {
    if (element.value.length >= minLength) {
        formErrorMessage(element, true);
        console.log(element);
    }
    else {
        formErrorMessage(element, false);
    }

};


const formErrorMessage = (element, validationResult) => {
    let spanElement = document.querySelector(`[data-valmsg-for="${element.name}"]`);


    if (validationResult) {
        element.classList.remove('input-validation-error');
        spanElement.classList.remove('field-validation-error');
        spanElement.classList.add('field-validation-valid');
        spanElement.innerHTML = '';
    }
    else {
        element.classList.add('input-validation-error');
        spanElement.classList.add('field-validation-error');
        spanElement.classList.remove('field-validation-valid');
        spanElement.innerHTML = element.dataset.ValRequired;
    }
}

const checkBoxValidator = (element) => {


    if (element.checked) {
        formErrorMessage(element, true);
        console.log(element);
    }
    else {
        formErrorMessage(element, false);
        console.log('test');
    }
}

const emailValidator = (element) => {
    const emailRegEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$/;
    formErrorMessage(element, emailRegEx.test(element.value));
}

const passwordValidator = (element) => {

    if (element.dataset.ValEqualtoOther !== undefined) {
        formErrorMessage(element, compareValidator(element.value, document.getElementsByName(element.dataset.ValEqualtoOther.replace('*', 'Form')[0].value)));
    }
    else {
        const passwordRegEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$/;
        formErrorMessage(element, passwordRegEx.test(element.value));
    
    }

}

let forms = document.querySelectorAll('form');
let inputs = document.querySelectorAll('input');

inputs.forEach(input => {
    if (input.dataset.val === "true") {

        if (input.type === 'checkbox') {
            input.addEventListener('change', (e) => {
                checkBoxValidator(e.target);
            })
        }
        else {
            input.addEventListener('keyup', (e) => {
                switch(e.target.type) {
                    case 'text':
                        textValidator(e.target);
                        break;
                    case 'email':
                        emailValidator(e.target);
                        break;
                    case 'password':
                        passwordValidator(e.target);
                        break;
                }

            })
        }

    }
})