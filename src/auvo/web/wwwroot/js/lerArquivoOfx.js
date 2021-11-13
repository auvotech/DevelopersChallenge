$(document).ready(function () {
    function handleFileSelect(evt) {
        let reader = new FileReader();
        let file = document.querySelector('.fileInput').files[0];

        reader.onload = function (file) {
           var ofx =  file.target.result.substring(file.target.result.indexOf("<OFX>"))
           console.log(ofx)
        };
        
        reader.readAsText(file);
    }

    document.getElementById("btn-include-file").addEventListener('click', handleFileSelect, false);




})


