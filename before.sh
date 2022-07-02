wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt update
sudo apt-get install -y apt-transport-https 
sudo apt-get update
sudo apt-get install -y dotnet-sdk-6.0
sudo apt install -y dirmngr gnupg apt-transport-https ca-certificates software-properties-common
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
sudo apt-add-repository 'deb https://download.mono-project.com/repo/ubuntu stable-focal main'
sudo apt install -y mono-complete 
dotnet restore
chmod +g Godot/Godot
chmod +x Godot/Godot