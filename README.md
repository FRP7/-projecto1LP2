# Projeto 1

 **Francisco Pires a21804873:**
 

 - Planeamento, organização e gestão do projeto.
 - Leitura do ficheiro (`FileReader`) .
 - `Planet` e `Star`.
 - `PlanetField` e `StarField`.
 - Pesquisa e ordenação de estrelas.
 - Ordenação dos planetas.
 - *Polishing* e documentação do código.
 - Relatório.

 **Nuno Figueiredo a21705451:**
 

 - teste1
 - teste2
 - teste3
 
 **Repositório**: https://github.com/FRP7/projecto1LP2

# Arquitectura da solução

**Forma de implementação:** Interativo, consola.

**Descrição da solução:**


**Organização:**

A solução foi feita tentando sempre que possível respeitar os princípios *SOLID*, para isso utilizámos como *Design Pattern* o *Facade*. O motivo para esta escolha foi, pensei que como o projeto seria em grupo e o Nuno tem dificuldades em programação, seria o estilo mais ideal e mais confortável para trabalharmos juntos sem quaisquer tipos de problemas a nível de compreensão e de *Source Control*.

**Leitura do ficheiro:**

Para ler o ficheiro, tive que utilizar o `StreamReader` do `System.IO` e logicamente, o código passa à frente do texto que tenha "*#*" até chegar a um que não tenha (que são as colunas). Depois aí, divide a linha por vírgulas e coloca num *array* que depois o tipo de colunas são identificadas por um *array* de `int` através do *index*.
Após a identificação das colunas, o código verifica o resto do ficheiro que com o *index* vai percebendo a qual coluna pertencem e vai colocando na coleção. 
O conteúdo dos campos das colunas é convertido para os formatos mais adequados do C# através do `TryParse` (excepto quando se trata de `string`). `Nullables` são utilizados nas variáveis de valor visto que nem todos os dados contêm toda a informação que pedem as colunas.

**Coleção:**

A coleção que utilizámos foi o `Dictionary`. O motivo para esta decisão foi que numa perspectiva de fora, creio que faz todo o sentido guardar os dados num tabela semelhante a *SQL* e o facto de utilizar *Keys* é bastante poderoso e útil e poderá expandir os horizontes. As coleções só permitem em cada linha uma `Key` única e um valor, como os planetas e as estrelas têm mais do que um parâmetro, concluí que seria melhor criar duas `Struct` para serem utilizadas como valor (visto que é um tipo de valor), uma para as estrelas e outra para os planetas. E aí pude organizar bem os dados e tornar o código mais compreensível.

**Queries:**

Eu comecei primeiro por fazer as pesquisas das estrelas de forma que o Nuno pudesse entender melhor como poderia fazer a pesquisa dos planetas, por isso,  escrevi o código de forma que fosse parecido com *queries* de *SQL* para melhor compreensão.
Fiz *queries* para pesquisar por todos os parâmetros das estrelas e depois o Nuno fez os dos planetas com base no que fiz das estrelas. 
Por fim, fiz os *queries* de ordenação nas estrelas que depois o Nuno implementou nos planetas.

**UML:**


https://imgur.com/a/ztaVQuU

[![](https://i.imgur.com/rFot8kN.jpg)](https://i.imgur.com/rFot8kN.jpg)



## Referências

Para criar a coleção, utilizei esta solução (a que tem mais votos) nesta discussão no *StackOverflow*: https://stackoverflow.com/questions/6709625/c-sharp-dictionary-with-multiple-values-per-key.
Para ordenar os dados de uma forma mais dinâmica utilizei esta solução no *StackOverflow* proposta pelo professor (a que tem mais votos): https://stackoverflow.com/questions/2728340/how-can-i-do-an-orderby-with-a-dynamic-string-parameter/10413311#10413311

Para criar a coleção, inspirei-me numa solução que foi apresentada nesta discussão no StackOverflow: https://stackoverflow.com/questions/6709625/c-sharp-dictionary-with-multiple-values-per-key.

```cs
class MyType
{
    public string SomeVal1{ get; set; }
    public string SomeVal2{ get; set; }
    public bool SomeVal3{ get; set; }
    public bool SomeVal4{ get; set; }
    public int SomeVal5{ get; set; }
    public bool SomeVal6{ get; set; }
}
```
```
var someDictionary = new Dictionary<int, MyType>();
```
```cs
someDictionary.Add( 0, 
                    new MyType{
                        SomeVal1 = "foo",
                        SomeVal2 = "bar",
                        SomeVal3 = true,
                        SomeVal4 = false,
                        SomeVal5 = 42,
                        SomeVal6 = true
                    });

//someDictionary[0].SomeVal2 // bar
```

Para ordenar os dados de uma forma mais dinâmica, inspirei-me nesta solução no *StackOverflow* proposta pelo professor: https://stackoverflow.com/questions/2728340/how-can-i-do-an-orderby-with-a-dynamic-string-parameter/10413311#10413311.

```cs
Func<Item, Object> orderByFunc = null;
```
```
if (sortOrder == SortOrder.SortByName)
  orderByFunc = item => item.Name;
else if (sortOrder == SortOrder.SortByRank)
  orderByFunc = item => item.Rank;
```
```cs
var sortedItems = items.OrderBy(orderByFunc);
```
