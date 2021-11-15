function deletarArquivos() {

    var r = confirm("Deseja excluir as transações?");
    if (r == true) {
        $.ajax({
            method: "DELETE",
            url: url,
        })
            .done(function (result) {
                window.document.location.reload(true);
            })
        return;
    }


}