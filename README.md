# CodeQL language matrix exercise!

This exercise checks your knowledge of configuring a CodeQL language matrix, and configures a self-hosted runner.

## Configure a self-hosted runner using docker

# Docker Installation Guide

Docker allows you to develop, ship, and run applications in containers. This guide provides instructions for installing Docker on popular operating systems.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Installation on Windows](#installation-on-windows)
- [Installation on macOS](#installation-on-macos)
- [Installation on Linux](#installation-on-linux)
  - [Ubuntu](#ubuntu)
  - [CentOS](#centos)
  - [Debian](#debian)
- [Post-Installation Steps](#post-installation-steps)
- [Verify Docker Installation](#verify-docker-installation)

## Prerequisites
- Ensure your system meets Docker's [system requirements](https://docs.docker.com/get-docker/).
- Administrative (root) privileges to install packages.

## Installation on Windows

1. Download Docker Desktop for Windows from [Docker’s official website](https://desktop.docker.com/win/stable/Docker%20Desktop%20Installer.exe).
2. Run the installer and follow the prompts.
3. Once installation completes, Docker will launch automatically. You may need to enable Windows Subsystem for Linux (WSL) 2 integration for improved performance.

## Installation on macOS

1. Download Docker Desktop for Mac from [Docker’s official website](https://desktop.docker.com/mac/stable/Docker.dmg).
2. Open the downloaded `.dmg` file and drag Docker to your Applications folder.
3. Open Docker from the Applications folder to complete the installation.

## Installation on Linux

### Ubuntu

1. Update existing package list:
   ```bash
   sudo apt update
to install docker

2. Update existing package list:
   ```bash
   sudo apt install apt-transport-https ca-certificates curl software-properties-common
3. Add Docker’s official GPG key:
   ```bash
   curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg
4. Set up Docker’s stable repository:
   ```bash
   echo "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
5. Set up Docker’s stable repository:
   ```bash
   sudo apt update
   sudo apt install docker-ce docker-ce-cli containerd.io
### CENTOS
1. Install required packages:
   ```bash
   sudo yum install -y yum-utils
2. Add Docker’s repository:
   ```bash
   sudo yum-config-manager --add-repo https://download.docker.com/linux/centos/docker-ce.repo
3. Install Docker:
   ```bash
   sudo yum install -y docker-ce docker-ce-cli containerd.io
4. Start and enable Docker:
   ```bash
   sudo systemctl start docker
   sudo systemctl enable docker
### Debian

1. Update your package list
   ```bash
   sudo apt update
2. Install dependencies:
   ```bash
   sudo apt install apt-transport-https ca-   certificates curl software-properties-common
3. Add Docker’s official GPG key:
   ```bash
   curl -fsSL https://download.docker.com/linux/debian/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

4. Set up Docker’s stable repository:
   ```bash
   echo "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/debian $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
5. Install Docker:
   ```bash
   sudo apt update
   sudo apt install docker-ce docker-ce-cli   containerd.io
### Post-Installation Steps
To run Docker commands without sudo, add your user to the docker group:
   ```bash
   sudo usermod -aG docker $USER
```
After running the command, log out and log back in to apply the changes.
### Verify Docker Installation
Run the following command to check if Docker is installed correctly:
   ```bash
   docker --version
  ```
#### Create a GitHub Token
Go to GitHub and generate a Personal Access Token (PAT) with the repo and workflow permissions. This token will allow the runner to register itself with your GitHub repository or organization.
#### Run the Docker Container for the Self-Hosted Runner
Use the official GitHub Actions Runner Docker image to set up a containerized self-hosted runner.
1. Run the following command to start the container. Replace YOUR_GITHUB_TOKEN, YOUR_GITHUB_ORG, and YOUR_GITHUB_REPO with your details:
```bash
docker run -d \
  --name github-runner \
  -e REPO_URL="https://github.com/YOUR_GITHUB_ORG/github-advanced-security-codeql-demo" \
  -e RUNNER_TOKEN="YOUR_GITHUB_TOKEN" \
  -e RUNNER_NAME="docker-runner" \
  -e RUNNER_WORKDIR="/tmp/github-runner" \
  -e LABELS="self-hosted" \
  -v /var/run/docker.sock:/var/run/docker.sock \
  myoung34/github-runner:latest
```
use ``` --platform linux/amd64 ``` if you are using a Mac Silicon
### GitHub Self-Hosted Runner Environment Variables and Options


1. **`RUNNER_TOKEN`**
   GitHub token required for authentication. This token is created on GitHub to authorize and register the runner securely.

2. **`RUNNER_NAME`**
   A customizable name or identifier for the runner. You can set it to any unique name to easily identify the runner in GitHub Actions.

3. **`RUNNER_WORKDIR`**
   Specifies the working directory for the runner within the container. This is where files related to workflow executions will be stored.

4. **`LABELS`**
   Allows you to assign labels to the runner, like "self-hosted" Labels help in categorizing and selecting runners for specific workflows in GitHub Actions.

5. **`-v /var/run/docker.sock:/var/run/docker.sock`**
   This mounts the Docker socket inside the container. By exposing the Docker socket, the runner can start and manage other Docker containers from within the runner container itself, useful for workflows that need Docker.

### Summary
This setup enables the runner to interact with Docker containers, making it versatile for CI/CD tasks that require containerized builds or tests.

### Verify the Runner Registration

1. After running the command, go to your repository or organization’s Settings > Actions > Runners.
2. You should see your new runner listed there with the specified name and labels.
## Use the Self-Hosted Runner in GitHub Workflows
Use the Self-Hosted Runner in GitHub Workflows:
```bash
jobs:
  example-job:
    runs-on: [self-hosted]
    steps:
      - name: Checkout code
        uses: actions/checkout@v2

```
### Desable all C# CodeQL Revisison

# Skipping a Language in CodeQL GitHub Analysis

To skip a specific language in CodeQL analysis on GitHub, you can customize the CodeQL configuration in your GitHub Actions workflow. If your repository has code in multiple languages but you only want to analyze specific ones, you can specify this in the `language` field of the CodeQL action.

## Steps to Configure CodeQL to Skip a Language

1. **Set Specific Languages**: In your CodeQL workflow YAML file, use the `language` option to specify only the languages you want to analyze. Any language not listed will be skipped.

   ```yaml
   - name: Initialize CodeQL
     uses: github/codeql-action/init@v3
     with:
       languages: javascript, python # Add only the languages you want to include
2. Navigate to Your Repository
Go to the main page of your GitHub repository.

3. Access Actions
Select the Actions tab from the repository menu to view your existing workflows.

4. Locate the CodeQL Workflow
Find the CodeQL Analysis workflow in the list of workflows. If it’s not immediately visible, use the search bar to locate it.

5. Edit the Workflow File

## CodeQL Code scanning

let's add this code in java in order to detect vulnerabilities with the use of CodeQL on this route ```Java/src/main/java/com/.classpath ```

```java
import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class FooServlet extends HttpServlet {
  protected void doGet(HttpServletRequest request, HttpServletResponse response)
  throws ServletException, IOException {
    // String cardSecurityCode = "12345";
    // User provided value
    String cardSecurityCode = request.getParameter("cardSecurityCode");
    Runtime.getRuntime().exec("validateCode.sh " + cardSecurityCode);
  }
}
 ```


