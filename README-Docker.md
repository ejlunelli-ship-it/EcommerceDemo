# ECommerce Demo - Docker Configuration

## ?? Portas Configuradas

### Portas Padrão
- **API**: `http://localhost:5100`
- **Swagger**: `http://localhost:5100/swagger`
- **SQL Server**: `localhost:1434`

### Configurações para Visual Studio

#### Método 1: Automático (Recomendado)
O Visual Studio irá automaticamente encontrar portas disponíveis usando os arquivos:
- `docker-compose.vs.debug.yml` - Para Debug
- `docker-compose.vs.release.yml` - Para Release

#### Método 2: Script PowerShell
Execute o script para encontrar portas disponíveis automaticamente:
```powershell
.\find-available-ports.ps1
```

#### Método 3: Manual
1. Abra `docker-compose.yml`
2. Altere as portas conforme necessário:
   ```yaml
   services:
     ecommerce.api:
       ports:
         - "NOVA_PORTA:8080"  # Ex: "5200:8080"
     db:
       ports:
         - "NOVA_PORTA:1433"  # Ex: "1435:1433"
   ```

## ?? Comandos Úteis

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
1. Defina o projeto `docker-compose` como projeto de inicialização
2. Selecione o perfil "Docker Compose" 
3. Execute com F5 ou Ctrl+F5

## ?? Profiles Disponíveis no Visual Studio

### launchSettings.json
- **ECommerce.Api**: Execução local HTTP (porta 5100)
- **ECommerce.Api.HTTPS**: Execução local HTTPS (portas 5100/5101)
- **Container (Dockerfile)**: Container único
- **Docker Compose**: Stack completa com banco

## ?? Verificar Portas em Uso

### Windows (PowerShell)
```powershell
# Ver portas em uso
netstat -ano | findstr :5100
netstat -ano | findstr :1434

# Ver processos usando uma porta específica
Get-Process -Id (Get-NetTCPConnection -LocalPort 5100).OwningProcess
```

### Liberar Porta (se necessário)
```powershell
# Parar processo por PID
Stop-Process -Id PID_NUMBER -Force

# Ou parar containers Docker
docker-compose down
```

## ??? Estrutura de Arquivos Docker

```
??? docker-compose.yml              # Configuração principal
??? docker-compose.override.yml     # Override para desenvolvimento
??? docker-compose.vs.debug.yml     # Visual Studio Debug
??? docker-compose.vs.release.yml   # Visual Studio Release
??? find-available-ports.ps1        # Script para encontrar portas
??? .dockerignore                   # Arquivos ignorados pelo Docker
??? src/
    ??? ECommerce.Api/
        ??? Dockerfile              # Dockerfile da API
        ??? Properties/
            ??? launchSettings.json # Configurações de inicialização
```

## ? Troubleshooting

### Porta em Uso
1. Execute o script `find-available-ports.ps1`
2. Ou altere manualmente as portas no `docker-compose.yml`
3. Reinicie os containers: `docker-compose down && docker-compose up -d`

### Visual Studio não encontra o serviço
1. Certifique-se que o projeto `docker-compose` está definido como projeto de inicialização
2. Verifique se os arquivos `.vs.debug.yml` e `.vs.release.yml` existem
3. Limpe e rebuild a solução

### Container não inicia
1. Verifique os logs: `docker-compose logs ecommerce.api`
2. Verifique se as portas estão disponíveis
3. Rebuilde a imagem: `docker-compose build --no-cache ecommerce.api`