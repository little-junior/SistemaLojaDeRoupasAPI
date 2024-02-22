# API para Sistema de Vendas de Loja de Roupas 🛍️

## Objetivo

Este projeto consiste em desenvolver uma API para atender as demandas de um sistema de vendas para uma loja de roupas. A API é responsável por:

- Registrar vendas, reembolsos ou trocas.
- Listar vendas, reembolsos e trocas.
- Permitir buscas com parâmetros para filtrar as listagens

Além disso, tem como requisitos a implementação de validações para os campos relevantes, filtrar exceções, fazer log no início e no fim das ações utilizando filtros, e aplicar uma política global de CORS para permitir acesso da origem especificada (http://localhost:5500).

## Requisitos

- .NET 8.0

## Endpoints

### Venda
- `GET /api/Venda`: Retorna todas as vendas.
- `GET /api/Venda/{id}` : Retorna a venda com o id especificado.
- `POST /api/Venda`: Registra uma nova venda.

### Devolucao

- `GET /api/Devolucao`: Retorna todas as devoluções (reembolsos e trocas).
- `GET /api/Devolucao/Troca`: Retorna todas as devoluções de troca.
- `GET /api/Devolucao/Troca/{id}`: Retorna a troca a partir do id especificado.
- `POST /api/Devolucao/Troca`: Registra uma troca.
- `GET /api/Devolucao/Reembolso`: Retorna todas as devoluções de reembolso.
- `GET /api/Devolucao/Reembolso/{id}`: Retorna o reembolso a partir do id especificado.
- `POST /api/Devolucao/Reembolso`: Registra um reembolso.


## Assuntos abordados

- Implementação de endpoints RESTful
- Validação de campos nos requests
- Filtro para capturar exceções
- Utilização de logs
- Política CORS