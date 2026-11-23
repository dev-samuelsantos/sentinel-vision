# Sentinel Vision

Projeto de estudo em C#/.NET, desenvolvido incrementalmente para explorar o processamento de detecções e fundamentos de visão computacional.

## Estado atual

Aplicação de console com dados simulados:

- Modelagem de detecções com classe, confiança, posição e tamanho.
- Filtragem por limite de confiança.
- Exibição das detecções aprovadas.
- Contagem de detecções aprovadas e rejeitadas.

Ainda não há processamento de imagens ou integração com modelos de visão computacional.

## Como executar

Requisito: SDK do .NET 10.

```sh
dotnet run
```

## Como executar os testes

Os testes usam xUnit e verificam cálculo de área, classificação por tamanho,
aprovação por confiança e prioridade. Incluem os limites de 50.000 e 150.000
pixels² e confiança exatamente igual ao limite configurado.

```sh
dotnet test tests/Sentinel.Tests/Sentinel.Tests.csproj
```

## Desenvolvimento

O projeto evolui por pequenas etapas de estudo: compreender o problema, implementar, validar o comportamento e registrar a mudança em um commit.

Próximas etapas incluem validação dos dados e resultados estruturados de processamento. A integração com modelos de visão computacional faz parte da evolução futura.
