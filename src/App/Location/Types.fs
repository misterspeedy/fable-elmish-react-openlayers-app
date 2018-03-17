module Location.Types
open Fable.Import
open Fable.Helpers

type Model = {
    name: string
    imageTypeIndex: int
    coordinate: OpenLayers.Ol.Coordinate
    zoom: float
    orientation: ReactOpenLayers.Orientation
}

type Msg =
  | ChangePlace of (string * OpenLayers.Ol.Coordinate * float)
  | ChangeOrientation of ReactOpenLayers.Orientation
