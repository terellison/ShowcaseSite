$repo = "https://github.com/terellison/" + $args[0] 
git clone $repo
$compress = @{
	Path = (".\" + $args[0] + "\*")
	CompressionLevel = "Fastest"
	DestinationPath = (".\" + $args[0] + ".zip")
}
Compress-Archive @compress
Rename-Item (".\" + $args[0] + ".zip") -NewName (".\" + $args[0] + ".love")
Remove-Item -Recurse -Force (".\" + $args[0])
$fileName = ($args[0] + ".love")
$dirName = ("./wwwroot/" + $args[0])
npx love.js -c $fileName $dirName --title $args[0]
Remove-Item -Force $fileName