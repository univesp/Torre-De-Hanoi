function UnityProgress(gameInstance, progress) {
  if (!gameInstance.Module)
    return;
  if (!gameInstance.logo) {
    gameInstance.logo = document.createElement("div");
    gameInstance.logo.className = "logo " + gameInstance.Module.splashScreenStyle;
    gameInstance.container.appendChild(gameInstance.logo);
  }
  if (!gameInstance.progresso) {
    gameInstance.progresso = document.createElement("div");
    gameInstance.progresso.className = "progresso " + gameInstance.Module.splashScreenStyle;
    gameInstance.progresso.empty = document.createElement("div");
    gameInstance.progresso.empty.className = "empty";
    gameInstance.progresso.appendChild(gameInstance.progresso.empty);
    gameInstance.progresso.full = document.createElement("div");
    gameInstance.progresso.full.className = "full";
    gameInstance.progresso.appendChild(gameInstance.progresso.full);
    gameInstance.container.appendChild(gameInstance.progresso);
  }
  gameInstance.progresso.full.style.width = (100 * progress) + "%";
  gameInstance.progresso.empty.style.width = (100 * (1 - progress)) + "%";
  if (progress == 1)
    gameInstance.logo.style.display = gameInstance.progresso.style.display = "none";
}
