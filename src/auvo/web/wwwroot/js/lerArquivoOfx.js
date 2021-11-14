function handleFileSelect(evt) {
    let reader = new FileReader();
    let file = document.querySelector('.fileInput').files[0];

    reader.onload = function (file) {
        var ofx = file.target.result.substring(file.target.result.indexOf("<OFX>"))
        salvarArquivos(ofx.toString().replace(/(\r\n|\n|\r)/gm, ""))
    };

    reader.readAsText(file);
}

function salvarArquivos(historico) {
    var objectToSend = { historico: historico };

    $('#table_id').DataTable({
        destroy: true,
        "dom": dataTableProperts.dom,
        "language": dataTableProperts.language,
        "ajax": {
            dataSrc: "",
            url: url,
            method: "POST",
            dataType: 'json',
            contentType: 'application/json',
            data: function (object) {
                return JSON.stringify(objectToSend)
            },
        },
        "columns": [
            { "data": "valor" },
            {
                "data": "dataLancamento",

                "render":function(data){
                    return data
                }
            }

        ]
        ,
    });
    $("div.toolbar").html(' </b> <br><input type="file" class="fileInput" multiple>  <br> <button   onclick="handleFileSelect()" id="btn-include-file" class="btn">Importar</button>');

}
