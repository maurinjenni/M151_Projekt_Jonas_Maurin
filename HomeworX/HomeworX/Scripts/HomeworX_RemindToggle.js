function toggle(id,openText,closedText) {
    var e = document.getElementById(id);
    var button = document.getElementById('aufklappButton');

    if (e.style.display == "none") {
        e.style.display = "";
        button.innerHTML = openText;
    } else {
        e.style.display = "none";
        button.innerHTML = closedText;
    }
}