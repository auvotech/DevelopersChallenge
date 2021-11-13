
$(document).ready(function () {
    $('#table_id').DataTable({
        "dom": '<"toolbar">frtip',
        "language": {
            "lengthMenu": "Itens exibidos  _MENU_ ",
            "sSearch": "Pesquisar",
            "info": "Exibindo _START_ de _END_ itens",
            'paginate': {
                'previous': 'Voltar',
                'next': 'Próximo'
            }
        }
    });
    $("div.toolbar").html(' <label class="input-file"> <b class="btn btn-primary"><i class="material-icons">Escolha o Arquivo</i> </b><input type="file" class="fileInput" multiple> </label>  <br> <button  id="btn-include-file" class="btn">Importar</button>');
});