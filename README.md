# Projeto 1

 **Francisco Pires a21804873:**
 

 - Planeamento, organização e gestão do projeto.
 - Leitura do ficheiro (`FileReader`) .
 - `Planet` e `Star`.
 - `PlanetField` e `StarField`.
 - Pesquisa e ordenação de estrelas.
 - Ordenação dos planetas.
 - *Polishing* e documentação do código.
 - Correção de *bugs*.
 - Relatório.


 **Nuno Figueiredo a21705451:**
 

 - Conceptualização e organização do `Menu`.
 -  Pesquisa de planetas.
 - Diversos métodos do `Facade`.
 - *Polishing* do código.
 - Correção de *bugs*.
 
 **Repositório**: https://github.com/FRP7/projecto1LP2

# Arquitectura da solução

**Forma de implementação:** Interativo, consola.



**Organização:**

A solução foi feita tentando sempre que possível respeitar os princípios *SOLID*, e para isso, utilizámos como *Design Pattern* o *Facade*. O motivo para esta escolha decorre do facto do projeto ser em grupo e o Nuno ter dificuldades em programação. Seria o estilo mais ideal e mais confortável para trabalharmos juntos sem quaisquer tipos de problemas a nível de compreensão e de *Source Control*.


**Leitura do ficheiro:**

Para ler o ficheiro, tive que utilizar o `StreamReader` do `System.IO` e logicamente, o código passa à frente do texto do ficheiro que tenha "*#*" até chegar a um que não tenha (que são as colunas). Depois aí, divide a linha por vírgulas e coloca num *array* e depois o tipo de colunas são identificadas por um *array* de `int` através do *index*.
Após a identificação das colunas, o código verifica o resto do ficheiro com o *index* que vai percebendo a qual coluna pertencem e vai colocando na coleção. 
O conteúdo dos campos das colunas é convertido para os formatos mais adequados do C# através do `TryParse` (excepto quando se trata de `string`). `Nullables` são utilizados nas variáveis de valor, visto que nem todos os dados contêm toda a informação que pedem as colunas.

**Coleção:**

A coleção que utilizámos foi o `Dictionary`. O motivo para esta decisão foi que numa perspectiva externa, creio que faz todo o sentido guardar os dados num tabela semelhante a *SQL* e o facto de utilizar *Keys* é bastante poderoso e útil para poder expandir os horizontes. As coleções só permitem em cada linha uma `Key` única e um valor. Como os planetas e as estrelas têm mais do que um valor, concluí que seria melhor criar duas `Struct` para serem utilizadas como valor (visto que são tipos de valor), uma para as estrelas e outra para os planetas. Aí pude organizar bem os dados e tornar o código mais compreensível.

**Queries:**

Eu comecei primeiro por fazer as pesquisas das estrelas de forma que o Nuno pudesse entender melhor como poderia fazer a pesquisa dos planetas, por isso,  escrevi o código de forma que fosse parecido com *queries* de *SQL* para melhor compreensão.
Fiz *queries* para pesquisar por todos os parâmetros das estrelas e depois, o Nuno fez os dos planetas com base no que fiz das estrelas. 
Por fim, fiz os *queries* de ordenação nas estrelas que depois o Nuno implementou nos planetas. Essas *queries* de ordenação incluem ordenação secundária para o caso de haver empate na ordenação primária.

**UML:**


https://imgur.com/a/ztaVQuU

[![](https://i.imgur.com/i99H0I2.jpg)](https://i.imgur.com/i99H0I2.jpg)



## Referências

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

Também tivemos que consultar a documentação do C# https://docs.microsoft.com/en-us/dotnet/csharp/  e os slides que o professor forneceu no moodle.
