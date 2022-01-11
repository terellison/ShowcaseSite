git clone https://github.com/terellison/$1
cd ./$1/
rm -r ./.git && rm ./.gitignore
zip -9 -r ../$1.love .
cd ..
rm -r $1
love.js -c $1.love ./wwwroot/$1 --title ${1}