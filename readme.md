
Parabéns, você avançou para a próxima fase e está mais próximo de integrar a equipe de alto desempenho da Auvo.


## O desafio
Você deverá criar um simples sistema que atenda à todos os requisitos de negócio e técnicos e nos enviar no prazo estipulado. 

### Problema
Bruna precisa [concilicar o extrato bancário](https://www.nibo.com.br/blog/como-fazer-conciliacao-bancaria-passo-passo/) da empresa com as entradas e saídas que ela registrou no Excel do último mês. Para isso é utilizado um arquivo do tipo OFX, que contém o registro do banco de todas as entradas e saídas de um período e é fácil de exportar pelo Bankline.

O problema é que Xayah baixou dois arquivos OFX: um que contém transações do dia 01 ao dia 20 e outro que contém transações do dia 15 ao 31. E agora ela não sabe o que fazer para garantir que todas as transações sejam conciliadas corretamente, uma vez que os arquivos OFX possuem transações de um período em comum.

### O que você deverá fazer
Criar um sistema onde ela possa importar dois ou mais arquivos OFX e, no final, poderá ver todas as transações bancárias que ocorreram no período.
Bruna deve poder ver a lista de transações por uma interface web responsiva e poder pesquisar transação dentro de um gap de datas. Além de poder abrir uma modal de detalhes de de cada transação para adicionar uma observação em texto.


Lembre-se que os arquivos OFX poderão conter transações de um mesmo período. Essas transações devem ser exibidas sem duplicidade. Também lembre-se de que é possível que existam transações do mesmo valor em um mesmo dia.

Os arquivos OFX estão na pasta ``\OFX``.

**Requisitos**
- [ ] É necessário persistir as transações finais.
- [ ] Não utilize bibliotecas específicas para a leitura de arquivos do tipo OFX.
- [ ] Você deverá desenvolver uma solução **WEB** em C# .NET core 2.1 e jquery 
- [ ] Você  deverá utilizar MVC na criação da sua interface.
- [ ] Sua interface deve conter um campo de upload de arquivos com uma grid que list o resultado do processamento.
- [ ] Na grid de listagem deve ter um botão de visualização que abra uma modal com um campo para inserir uma observação.
- [ ] Queremos como resultado uma solução simples, legível e de qualidade. 
- [ ] Não utilize soluções prontas. 
- [ ] Seja criativo. Você decide quais funcionalidades irá incluir além dos requisitos.
- [ ] Não hospede sua aplicação ou parte dela em nenhum lugar. Sua aplicação deverá rodar localmente sem depender de serviços externos.

## Envio da solução
Você deverá criar um fork deste repositório, incluir o seu código fonte na pasta ``SRC``,  preencher o formulário "_about/Profile.md" e enviar para o email do seu recrutador o link do seu fork.

Desejamos a você uma ótima experiência code.

Créditos do desafio base: Rafael Heringer
