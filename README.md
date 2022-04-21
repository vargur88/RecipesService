# RecipesService
Example web-project based on .net Core and Mendix technology

# Requirements
 - .NET 5.0
 - MX Studio Pro 9

# How to start

## .net app via docker
Find at RecipesService folder docker file and execute listed commands

```bash
docker build . --tag rs-test
```

```bash
docker run -p 9091:80 -d --rm rs-test
```
swagger on address: 'http://localhost:9091/swagger'


## Mendix app via MX Studio Pro 9
Open file RecipesService.mpr at RecipesServiceMendix folder and press button 'Run locally'