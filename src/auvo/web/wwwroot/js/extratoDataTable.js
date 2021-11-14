

$(document).ready(function () {
    $('#table_id').DataTable({
        "dom": dataTableProperts.dom,
        "language":dataTableProperts.language
    });
    $("div.toolbar").html(' </b> <br><input type="file" class="fileInput" multiple>  <br> <button   onclick="handleFileSelect()" id="btn-include-file" class="btn">Importar</button>');
});

