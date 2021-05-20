function googleTranslateElementInit() {
    new google.translate.TranslateElement({ pageLanguage: 'en', layout: google.translate.TranslateElement.InlineLayout.SIMPLE }, 'google_translate_element');
}
function openForm() {
    document.getElementById("myForm").style.display = "block";
    
}
function closeForm() {
    document.getElementById("myForm").style.display = "none";
}
function cookieAlert() {
    var a = confirm("This website uses cookies in order to improve your experience. Do you accept this website's cookies?");
    if (x == true) {
        exit
    } else {
        quit
    }
}