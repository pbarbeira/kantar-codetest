FROM mcr.microsoft.com/mssql/server:2022-latest

USER root

# Install sqlcmd tools on Debian 12 (Bookworm)
RUN apt-get update && \
    apt-get install -y curl gnupg && \
    mkdir -p /usr/share/keyrings && \
    curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > /usr/share/keyrings/microsoft-prod.gpg && \
    echo "deb [arch=amd64 signed-by=/usr/share/keyrings/microsoft-prod.gpg] https://packages.microsoft.com/debian/12/prod bookworm main" > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> /etc/bash.bashrc

COPY Scripts/init.sh /init.sh
COPY Scripts /Scripts

RUN chmod +x /init.sh

USER mssql

CMD ["/bin/bash", "/init.sh"]

