function obterTransacao(id) {
    $.ajax({
        method: "GET",
        url: `https://localhost:5001/transacao/${id}`,
    })
        .done(function (result) {
            $("#operacao").html(result.operacao == "DEBIT" ? "Débito" : "Crédito");
            $("#descricao").html(result.descricao);

            
            //console.log(result)
        })
}



var url = "https://localhost:5001/transacao";


var dataTableProperts = {
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
}

var coluns = [
    { "data": "valor" },
    {
        "data": "dataLancamento",

        "render": function (data) {
            return data
        }
    },

    {
        "data": "id",

        "render": function (id) {
            //return "<a> </a>"
            return `<button type='button' onclick='obterTransacao(${id})' class='btn ' data-toggle='modal' data-target='#exampleModal'>🔎 </button>`
        }
    }

]
