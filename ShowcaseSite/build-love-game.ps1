git clone https://github.com/terellison/${args[0]}
$compress = {
	Path = ".\${args[0]}",
	CompressionLevel = "Fastest",
	DestinationPath = ".\${args[0]}.love"
}
Compress-Archive @compress
rm -r ".\${args[0]}"
love.js -c ${args[0]}.love ./wwwroot/${args[0]} --title ${args[0]}