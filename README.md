# Unity Screen Manager

Este projeto Unity demonstra como gerenciar a navegação entre diferentes telas (Canvas) usando prefabs. O `ScreenManager` é responsável por carregar e configurar telas dinâmicas com base em uma lista de prefabs pré-registrados.

## Estrutura do Projeto

O projeto é composto pelos seguintes scripts principais:

- `ScreenManager.cs`
- `CanvasScreen.cs`
- `ScreenCanvasController.cs`
- `ScreenPrefab.cs`

### ScreenManager.cs

O `ScreenManager` gerencia a criação e destruição das telas. Ele também mantém um dicionário de prefabs de tela registrados e lida com a navegação entre telas.

### CanvasScreen.cs

O `CanvasScreen` é um componente que deve ser anexado a cada prefab de tela. Ele gerencia a ativação e desativação das telas e configura os dados de navegação (próxima e anterior tela) com base no `ScreenPrefab`.

### ScreenCanvasController.cs

O `ScreenCanvasController` é responsável por registrar os prefabs de tela com o `ScreenManager` e iniciar a tela inicial.

### ScreenPrefab.cs

O `ScreenPrefab` armazena as informações sobre cada tela, incluindo seu nome e as referências para as telas anterior e próxima.

## Como Configurar

### Crie Prefabs de Tela

- Cada tela deve ser um prefab com os componentes `CanvasScreen` e `ScreenPrefab`.
- Configure as propriedades `screenName`, `nextScreenName` e `previusScreenName` no `ScreenPrefab`.

### Adicione o ScreenManager à Cena

- Crie um GameObject vazio na sua cena e adicione o componente `ScreenManager`.
- Defina o `screenSpawnMainParent` no Inspector para o Transform onde os prefabs das telas serão instanciados.

### Configure o ScreenCanvasController

- Adicione o componente `ScreenCanvasController` a um GameObject na sua cena.
- Preencha a lista `screenPrefabs` no Inspector com os nomes das telas e os prefabs correspondentes.
