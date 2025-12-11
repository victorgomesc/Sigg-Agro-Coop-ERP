#!/bin/bash

PROJECT_INFRA="src/SiggAgroCoop.Infrastructure"
PROJECT_API="src/SiggAgroCoop.Api"

function create_migration() {
    NAME=$1
    if [ -z "$NAME" ]; then
        echo "Erro: informe o nome da migration."
        exit 1
    fi

    dotnet ef migrations add "$NAME" \
        --project $PROJECT_INFRA \
        --startup-project $PROJECT_API \
        --output-dir Migrations
}

function update_db() {
    dotnet ef database update \
        --project $PROJECT_INFRA \
        --startup-project $PROJECT_API
}

function revert_migration() {
    NAME=$1
    if [ -z "$NAME" ]; then
        echo "Erro: informe o nome da migration para reverter."
        exit 1
    fi

    dotnet ef database update "$NAME" \
        --project $PROJECT_INFRA \
        --startup-project $PROJECT_API
}

case $1 in
    "add")
        create_migration $2
        ;;
    "update")
        update_db
        ;;
    "revert")
        revert_migration $2
        ;;
    *)
        echo "Uso:"
        echo "./manage-db.sh add NomeDaMigration"
        echo "./manage-db.sh update"
        echo "./manage-db.sh revert NomeDaMigration"
        ;;
esac
