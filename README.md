# ShipIt! 🚀

> A simple deployment manager for Docker Compose applications running on a VPS.

ShipIt watches your container registry, detects new image versions and helps you deploy them safely with a single click.

No SSH.
No Kubernetes.
No complex CI/CD pipelines.

Just build your Docker image, push it to GHCR and ShipIt takes care of the rest.

---

## Why?

There are plenty of great tools:

* Kubernetes – powerful, but often overkill for a single VPS.
* Coolify – a full PaaS platform.
* Portainer – manages Docker infrastructure.
* Watchtower – automatically updates containers.

ShipIt focuses on one thing:

> Keeping your Docker Compose applications up to date.

---

## Features

* 📦 Detect new images in GitHub Container Registry
* 🚀 One-click deployments
* 📜 Deployment history
* 🔄 Rollback to previous versions
* ❤️ Health checks
* 🐳 Docker Compose first

---

## Non-goals

ShipIt is **not**:

- a Kubernetes replacement
- a PaaS
- a Docker management tool
- a monitoring platform
- a reverse proxy manager
- a CI server

It only solves one problem:

**Deploy Docker Compose applications running on a VPS.**

---

## Philosophy

ShipIt is built around a few simple principles:

* Docker Compose is the source of truth.
* Configuration lives in files, not in a database.
* SQLite stores runtime state and deployment history only.
* Applications are first-class citizens, not containers.
* Simplicity beats flexibility.

---

## Current status

🚧 Early development.

The project is not ready for production use yet.

## Roadmap

- [ ] Discover applications
- [ ] Docker integration
- [ ] GHCR image detection
- [ ] One-click deployment
- [ ] Deployment history
- [ ] Rollback
- [ ] Health checks
- [ ] Auto deploy

Contributions, ideas and feedback are welcome.
