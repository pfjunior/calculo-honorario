#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "postgres" <<-EOSQL
	CREATE DATABASE calculohonorario;
	GRANT ALL PRIVILEGES ON DATABASE CalculoHonorario TO postgres;
EOSQL

psql -U postgres -d calculohonorario -f sql/initial.sql
psql -U postgres -d calculohonorario -f sql/vr-vt-nullable.sql