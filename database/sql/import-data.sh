# Aguardando alguns segundos para aguardar o provisonamento e inicialização do banco de dados
sleep 60s

# Rodar o comando para criar o banco de dados
/opt/mssql-tools/bin/sqlcmd -S localhost, 1433 -U SA -P "express@CHDB" -i initial.sql