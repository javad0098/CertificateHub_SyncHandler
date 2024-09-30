
```markdown
# Kubernetes Setup for Certificate Service

This repository contains Kubernetes configuration files for deploying and exposing a service called `certificateservice`. Below are the instructions on how to deploy these configurations in a Kubernetes cluster.

## Overview

The following Kubernetes YAML files are provided:

- `certificates-depl.yaml`: Contains the Deployment configuration for the `certificateservice`.
- `certificate-np-srv.yaml`: Contains the Service configuration for the `certificateservice`.

## Prerequisites

1. **Kubernetes Cluster**: Ensure you have a Kubernetes cluster running. You can use Minikube, kubeadm, or any managed Kubernetes service (e.g., Google Kubernetes Engine, Amazon EKS, Azure Kubernetes Service).

2. **kubectl**: Ensure you have `kubectl` installed and configured to interact with your Kubernetes cluster.

## Instructions

### 1. Apply the Kubernetes Configuration

Navigate to the folder where your YAML files are located.

```bash
cd /path/to/CertificateHub/k8s
```

#### 1.1 Create the Deployment

Apply the `certificates-depl.yaml` file to create the Deployment:

```bash
kubectl apply -f certificates-depl.yaml
```

This will create a Deployment named `certificate-depl` which runs a single replica of the `certificateservice` container with the image `javad0098/certificateservice:latest`.

#### 1.2 Create the Service

Apply the `certificate-np-srv.yaml` file to create the Service:

```bash
kubectl apply -f certificate-np-srv.yaml
```

This will create a Service named `certificateservice-srv` of type `NodePort` which exposes the `certificateservice` Deployment on port 80.

### 2. Verify the Deployment and Service

#### 2.1 Check Deployment

Verify that the Deployment is created and running:

```bash
kubectl get deployments
```

You should see `certificate-depl` listed.

#### 2.2 Check Pods

Verify that the Pod(s) are running:

```bash
kubectl get pods
```

You should see Pods associated with `certificate-depl` in the `Running` state.

#### 2.3 Check Service

Verify that the Service is created and get the NodePort assigned:

```bash
kubectl get services
```

You should see `certificateservice-srv` listed with a `NodePort` in the `PORT(S)` column. The output will look something like this:

```
NAME                      TYPE       CLUSTER-IP     EXTERNAL-IP   PORT(S)        AGE
certificateservice-srv   NodePort   10.0.0.123     <none>        80:XXXXX/TCP   10m
```

The `XXXXX` is the port assigned to the `certificateservice` Service on your nodes.

### 3. Access the Service

To access the `certificateservice` from outside the cluster, use the Node’s IP address and the `NodePort`:

```
http://<NodeIP>:<NodePort>
```

Replace `<NodeIP>` with the IP address of your node and `<NodePort>` with the port number obtained from the `kubectl get services` output.

## Cleanup

To delete the Deployment and Service, use the following commands:

```bash
kubectl delete -f certificates-depl.yaml
kubectl delete -f certificate-np-srv.yaml
```

This will remove both the Deployment and the Service from your cluster.

## Additional Resources

- [Kubernetes Documentation](https://kubernetes.io/docs/home/)
- [kubectl Cheat Sheet](https://kubernetes.io/docs/reference/kubectl/cheatsheet/)

Feel free to modify the YAML files and commands as per your specific requirements.

```

This `README.md` file provides a comprehensive guide for deploying and managing your `certificateservice` in a Kubernetes environment, ensuring the process is clear and easy to follow for anyone who uses the repository.
