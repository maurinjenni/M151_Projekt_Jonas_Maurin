function toggle(id) {
    var e = document.getElementById(id);
    var button = document.getElementById('aufklappButton');

    if (e.style.display == "none") {
        e.style.display = "";
        button.innerHTML = "Zuklappen";
    } else {
        e.style.display = "none";
        button.innerHTML = "Errinnerung";
    }
}