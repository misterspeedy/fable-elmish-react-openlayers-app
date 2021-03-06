module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Types
open App.State
open Global

importAll "../../sass/main.sass"
importAll "ol/ol.css"

open Fable.Helpers.React
open Fable.Helpers.React.Props

let menuItem label page currentPage =
    li
      [ ]
      [ a
          [ classList [ "is-active", page = currentPage ]
            Href (toHash page) ]
          [ str label ] ]

// let menu currentPage =
//   aside
//     [ ClassName "menu" ]
//     [ p
//         [ ClassName "menu-label" ]
//         [ str "General" ]
//       ul
//         [ ClassName "menu-list" ]
//         [ menuItem "Image Type" ImageType currentPage ]]
let root model dispatch =

  let pageHtml =
    function
    | ImageType -> ImageType.View.root model.imageType (ImageTypeMsg >> dispatch)
    | Location -> Location.View.root model.location (LocationMsg >> dispatch)
    | ColorScheme -> ColorScheme.View.root model.colorScheme (ColorSchemeMsg >> dispatch)
    // | Location i ->
    //   // TODO horrible way of passing through image type
    //   let location = { model.location with imageTypeIndex = i }
    //   Location.View.root location (LocationMsg >> dispatch)

  div
    []
    [ div
        [ ClassName "navbar-bg" ]
        [ div
            [ ClassName "container" ]
            [ Navbar.View.root ] ]
      div
        [ (*ClassName "section"*) ]
        [ div
            [ ClassName "container" ]
            [ div
                [ ClassName "columns" ]
                [ // div
                  //  [ ClassName "column is-3" ]
                  //  [ menu model.currentPage ]
                  div
                    [ ClassName "column" ]
                    [ pageHtml model.currentPage ] ] ] ] ]

open Elmish.React
open Elmish.Debug
open Elmish.HMR

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash pageParser) urlUpdate
#if DEBUG
|> Program.withDebugger
|> Program.withHMR
#endif
|> Program.withReact "elmish-app"
|> Program.run
