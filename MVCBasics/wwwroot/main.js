var input = document.getElementById("temp-input");

function handleClick(radio) {

    if (radio.value == "celcius") {
        input.value = 37;
    }
    else if (radio.value == "farenheit") {
        input.value = 98;
    }
    else {
        input.value = 0;
    }

}