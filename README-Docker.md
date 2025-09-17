# ECommerce Demo - Docker Configuration

## ?? Portas Configuradas

### Portas Padr�o
- **API**: `http://localhost:5100`
- **Swagger**: `http://localhost:5100/swagger`
- **SQL Server**: `localhost:1434`

### Configura��es para Visual Studio

#### M�todo 1: Autom�tico (Recomendado)
O Visual Studio ir� automaticamente encontrar portas dispon�veis usando os arquivos:
- `docker-compose.vs.debug.yml` - Para Debug
- `docker-compose.vs.release.yml` - Para Release

#### M�todo 2: Script PowerShell
Execute o script para encontrar portas dispon�veis automaticamente:
```powershell
.\find-available-ports.ps1
```

#### M�todo 3: Manual
1. Abra `docker-compose.yml`
2. Altere as portas conforme necess�rio:
   ```yaml
   services:
     ecommerce.api:
       ports:
         - "NOVA_PORTA:8080"  # Ex: "5200:8080"
     db:
       ports:
         - "NOVA_PORTA:1433"  # Ex: "1435:1433"
   ```

## ?? Comandos �teis

### Docker Compose
```bash
# Subir os containers
docker-compose up -d

# Parar os containers
docker-compose down

# Rebuild e subir
docker-compose up -d --build

# Ver logs
docker-compose logs ecommerce.api
docker-compose logs db
```

### Visual Studio
1. Defina o projeto `docker-compose` como projeto de inicializa��o
2. Selecione o perfil "Docker Compose" 
3. Execute com F5 ou Ctrl+F5

## ?? Profiles Dispon�veis no Visual Studio

### launchSettings.json
- **ECommerce.Api**: Execu��o local HTTP (porta 5100)
- **ECommerce.Api.HTTPS**: Execu��o local HTTPS (portas 5100/5101)
- **Container (Dockerfile)**: Container �nico
- **Docker Compose**: Stack completa com banco

## ?? Verificar Portas em Uso

### Windows (PowerShell)
```powershell
# Ver portas em uso
netstat -ano | findstr :5100
netstat -ano | findstr :1434

# Ver processos usando uma porta espec�fica
Get-Process -Id (Get-NetTCPConnection -LocalPort 5100).OwningProcess
```

### Liberar Porta (se necess�rio)
```powershell
# Parar processo por PID
Stop-Process -Id PID_NUMBER -Force

# Ou parar containers Docker
docker-compose down
```

## ??? Estrutura de Arquivos Docker

```
??? docker-compose.yml              # Configura��o principal
??? docker-compose.override.yml     # Override para desenvolvimento
??? docker-compose.vs.debug.yml     # Visual Studio Debug
??? docker-compose.vs.release.yml   # Visual Studio Release
??? find-available-ports.ps1        # Script para encontrar portas
??? .dockerignore                   # Arquivos ignorados pelo Docker
??? src/
    ??? ECommerce.Api/
        ??? Dockerfile              # Dockerfile da API
        ??? Properties/
            ??? launchSettings.json # Configura��es de inicializa��o
```

## ? Troubleshooting

### Porta em Uso
1. Execute o script `find-available-ports.ps1`
2. Ou altere manualmente as portas no `docker-compose.yml`
3. Reinicie os containers: `docker-compose down && docker-compose up -d`

### Visual Studio n�o encontra o servi�o
1. Certifique-se que o projeto `docker-compose` est� definido como projeto de inicializa��o
2. Verifique se os arquivos `.vs.debug.yml` e `.vs.release.yml` existem
3. Limpe e rebuild a solu��o

### Container n�o inicia
1. Verifique os logs: `docker-compose logs ecommerce.api`
2. Verifique se as portas est�o dispon�veis
3. Rebuilde a imagem: `docker-compose build --no-cache ecommerce.api`