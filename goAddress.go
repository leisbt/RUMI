package main

import(
	"fmt"
	"net/http"
	nkns "simplenkn"
)

var nmc = nkns.GetNknMultiClient()
var c chan int

func main() {
	c = make(chan int)
	fmt.Println("Hello World")
	go listen()
	<- c
}

func handler(w http.ResponseWriter, r *http.Request) {
	switch (r.URL.Path) {
	case "/newAddress":
		w.Header().Set("Content-Type", "text/plain")
		w.WriteHeader(http.StatusOK)
		w.Write([]byte(nmc.Address()))
		c <- 1
	}
}

func listen() {
	http.HandleFunc("/", handler)
	http.ListenAndServe(":8080", nil)
}