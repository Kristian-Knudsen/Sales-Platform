CREATE USER postgres WITH PASSWORD 'postgrespswd';
CREATE DATABASE SalesPlatformDb OWNER postgres;
GRANT ALL PRIVILEGES ON DATABASE SalesPlatformDb TO postgres;