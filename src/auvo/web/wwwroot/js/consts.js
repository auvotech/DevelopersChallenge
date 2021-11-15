function obterTransacao(id) {
    $.ajax({
        method: "GET",
        url: `https://localhost:5001/transacao/${id}`,
    })
        .done(function (result) {
            $("#operacao").html(result.operacao == "DEBIT" ? "Débito" : "Crédito");
            $("#descricao").html(result.descricao);
            $("#idTransacao").html(result.id);
            $("#observacaoText").html(result.observacao);
        })
}



var url = "https://localhost:5001/transacao";


var dataTableProperts = {
    "dom": '<"toolbar">frtip',
    "language": {
        "lengthMenu": "Itens exibidos  _MENU_ ",
        "zeroRecords": "Nenhum registro correspondente encontrado",
        "infoEmpty": "0 Registro",
        "infoFiltered": "",


        "sSearch": "Pesquisar",
        "info": "Exibindo _START_ de _END_ itens",
        'paginate': {
            'previous': 'Voltar',
            'next': 'Próximo'
        }
    }
}

var coluns = [
    {
        "data": "valor",
        "render": function (data) {

            data = data.toString();
            let dataFormatada = parseFloat(data.substring(0, data.length - 2) + "." + data.slice(-2))
                .toLocaleString({ minimumFractionDigits: 2 });
                
            return dataFormatada.includes("-") ? ` <span style="color:red">R$ ${dataFormatada}</span>` : ` <span style="color:#446744">R$ ${dataFormatada}</span>`;
        }
    },
    {
        "data": "dataLancamento",

        "render": function (data) {
            return moment(data).format("DD/MM/YYYY")
        }
    },

    {
        "data": "id",

        "render": function (id) {
            return `<button type='button' onclick='obterTransacao(${id})' class='btn ' data-toggle='modal' data-target='#exampleModal'><i class="fas fa-search"></i> </button>`
        }
    }

]
