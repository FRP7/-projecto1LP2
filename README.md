# Projeto 1

 **Francisco Pires a21804873:**
 

 - Planeamento, organiza��o e gest�o do projeto.
 - Leitura do ficheiro (`FileReader`) .
 - `Planet` e `Star`.
 - `PlanetField` e `StarField`.
 - Pesquisa e ordena��o de estrelas.
 - Ordena��o dos planetas.
 - *Polishing* e documenta��o do c�digo.
 - Relat�rio.

 **Nuno Figueiredo a21705451:**
 

 - teste1
 - teste2
 - teste3
 
 **Reposit�rio**: https://github.com/FRP7/projecto1LP2

# Arquitectura da solu��o

**Forma de implementa��o:** Interativo, consola.

**Descri��o da solu��o:**


**Organiza��o:**

A solu��o foi feita tentando sempre que poss�vel respeitar os princ�pios *SOLID*, para isso utiliz�mos como *Design Pattern* o *Facade*. O motivo para esta escolha foi, pensei que como o projeto seria em grupo e o Nuno tem dificuldades em programa��o, seria o estilo mais ideal e mais confort�vel para trabalharmos juntos sem quaisquer tipos de problemas a n�vel de compreens�o e de *Source Control*.

**Leitura do ficheiro:**

Para ler o ficheiro, tive que utilizar o `StreamReader` do `System.IO` e logicamente, o c�digo passa � frente do texto que tenha "*#*" at� chegar a um que n�o tenha (que s�o as colunas). Depois a�, divide a linha por v�rgulas e coloca num *array* que depois o tipo de colunas s�o identificadas por um *array* de `int` atrav�s do *index*.
Ap�s a identifica��o das colunas, o c�digo verifica o resto do ficheiro que com o *index* vai percebendo a qual coluna pertencem e vai colocando na cole��o. 
O conte�do dos campos das colunas � convertido para os formatos mais adequados do C# atrav�s do `TryParse` (excepto quando se trata de `string`). `Nullables` s�o utilizados nas vari�veis de valor visto que nem todos os dados cont�m toda a informa��o que pedem as colunas.

**Cole��o:**

A cole��o que utiliz�mos foi o `Dictionary`. O motivo para esta decis�o foi que numa perspectiva de fora, creio que faz todo o sentido guardar os dados num tabela semelhante a *SQL* e o facto de utilizar *Keys* � bastante poderoso e �til e poder� expandir os horizontes. As cole��es s� permitem em cada linha uma `Key` �nica e um valor, como os planetas e as estrelas t�m mais do que um par�metro, conclu� que seria melhor criar duas `Struct` para serem utilizadas como valor (visto que � um tipo de valor), uma para as estrelas e outra para os planetas. E a� pude organizar bem os dados e tornar o c�digo mais compreens�vel.

**Queries:**

Eu comecei primeiro por fazer as pesquisas das estrelas de forma que o Nuno pudesse entender melhor como poderia fazer a pesquisa dos planetas, por isso,  escrevi o c�digo de forma que fosse parecido com *queries* de *SQL* para melhor compreens�o.
Fiz *queries* para pesquisar por todos os par�metros das estrelas e depois o Nuno fez os dos planetas com base no que fiz das estrelas. 
Por fim, fiz os *queries* de ordena��o nas estrelas que depois o Nuno implementou nos planetas.

**UML:**


https://imgur.com/a/ztaVQuU

[![](https://i.imgur.com/rFot8kN.jpg)](https://i.imgur.com/rFot8kN.jpg)



## Refer�ncias

Para criar a cole��o, utilizei esta solu��o (a que tem mais votos) nesta discuss�o no *StackOverflow*: https://stackoverflow.com/questions/6709625/c-sharp-dictionary-with-multiple-values-per-key.
Para ordenar os dados de uma forma mais din�mica utilizei esta solu��o no *StackOverflow* proposta pelo professor (a que tem mais votos): https://stackoverflow.com/questions/2728340/how-can-i-do-an-orderby-with-a-dynamic-string-parameter/10413311#10413311

Para criar a cole��o, inspirei-me numa solu��o que foi apresentada nesta discuss�o no StackOverflow: https://stackoverflow.com/questions/6709625/c-sharp-dictionary-with-multiple-values-per-key.

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

Para ordenar os dados de uma forma mais din�mica, inspirei-me nesta solu��o no *StackOverflow* proposta pelo professor: https://stackoverflow.com/questions/2728340/how-can-i-do-an-orderby-with-a-dynamic-string-parameter/10413311#10413311.

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
