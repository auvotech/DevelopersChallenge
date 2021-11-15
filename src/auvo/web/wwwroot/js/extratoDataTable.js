

$(document).ready(function () {
    $('#table_id').DataTable({
        "dom": dataTableProperts.dom,
        "language":dataTableProperts.language,
        "ajax": {
            dataSrc: "",
            url: url,
            method: "GET",
            dataType: 'json',
            contentType: 'application/json',
        },
        "columns":coluns,
    });
    $("div.toolbar").html(' </b> <br><input type="file" class="fileInput" multiple>  &nbsp&nbsp<br> <button   onclick="handleFileSelect()" id="btn-include-file" class="btn btn-sm btn-primary"><i class="fas fa-file-upload"></i></button>&nbsp&nbsp<button onclick="deletarArquivos()" class="btn btn-sm btn-danger"><i class="fas fa-trash"></i></button> <br><br>');
});

