<%@ Page Language="C#" AutoEventWireup="true" CodeFile="song.aspx.cs" Inherits="song" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link
      href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"
      rel="stylesheet"
      integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"
      crossorigin="anonymous"
    />
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta2/css/all.min.css"
      integrity="sha512-YWzhKL2whUzgiheMoBFwW8CKV4qpHQAEuvilg9FAn5VJUDwKZZxkJNuGM4XkWuk94WCrrwslk8yWNGmY1EduTA=="
      crossorigin="anonymous"
      referrerpolicy="no-referrer"
    />
    <link href="PageToSync/css/song.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light py-3">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">
          <img
            src="https://mtracks.azureedge.net/public/images/site/logo/en/logo-mono.svg"
            class="img-fluid"
            alt="Logo"
          />
        </a>
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                id="productDropDown"
                role="button"
                data-bs-toggle="dropdown"
                aria-expanded="false"
                href="#"
                >Products</a
              >
              <ul class="dropdown-menu" aria-labelledby="productDropdown">
                <li>
                  <a class="dropdown-item" href="#">The Connected Stage</a>
                </li>
                <li><a class="dropdown-item" href="#">Tracks</a></li>
                <li><a class="dropdown-item" href="#">Playback</a></li>
                <li><a class="dropdown-item" href="#">Playback for Mac</a></li>
                <li><a class="dropdown-item" href="#">Pad Player</a></li>
                <li><a class="dropdown-item" href="#">Playback Rentals</a></li>
                <li><a class="dropdown-item" href="#">Cloud Pro</a></li>
                <li><a class="dropdown-item" href="#">RehearsalMix</a></li>
                <li><a class="dropdown-item" href="#">ChartBuilder</a></li>
                <li>
                  <a class="dropdown-item" href="#">Solo Practice Bundle</a>
                </li>
                <li><a class="dropdown-item" href="#">Charts</a></li>
                <li>
                  <a class="dropdown-item" href="#">Pro Presenter Templates</a>
                </li>
                <li><a class="dropdown-item" href="#">Sounds</a></li>
              </ul>
            </li>
            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                id="songsDropdown"
                role="button"
                data-bs-toggle="dropdown"
                aria-expanded="false"
                href="#"
                >Songs</a
              >
              <ul class="dropdown-menu" aria-labelledby="songsDropdown">
                <li><a class="dropdown-item" href="#">Top Songs</a></li>
                <li><a class="dropdown-item" href="#">New Realeses</a></li>
                <li><a class="dropdown-item" href="#">Artists</a></li>
                <li><a class="dropdown-item" href="#">Albums</a></li>
              </ul>
            </li>
            <li class="nav-item">
              <a
                class="nav-link dropdown-toggle"
                id="soundDropdown"
                role="button"
                data-bs-toggle="dropdown"
                aria-expanded="false"
                href="#"
                href="#"
                >Sounds</a
              >
              <ul class="dropdown-menu" aria-labelledby="soundDropdown">
                <li><a class="dropdown-item" href="#">Top Songs</a></li>
                <li><a class="dropdown-item" href="#">New Realeses</a></li>
                <li><a class="dropdown-item" href="#">Artists</a></li>
                <li><a class="dropdown-item" href="#">Albums</a></li>
              </ul>
            </li>
            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                href="#"
                id="streamDropdown"
                role="button"
                data-bs-toggle="dropdown"
                aria-expanded="false"
              >
                Streaming
              </a>
              <ul class="dropdown-menu" aria-labelledby="streamDropdown">
                <li><a class="dropdown-item" href="#">Action</a></li>
                <li><a class="dropdown-item" href="#">Another action</a></li>
                <li><hr class="dropdown-divider" /></li>
                <li>
                  <a class="dropdown-item" href="#">Something else here</a>
                </li>
              </ul>
            </li>
            <li class="nav-item">
              <a
                class="nav-link disabled"
                href="#"
                tabindex="-1"
                aria-disabled="true"
                >Price</a
              >
            </li>
            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                href="#"
                id="moreDropDown"
                role="button"
                data-bs-toggle="dropdown"
                aria-expanded="false"
              >
                More
              </a>
              <ul class="dropdown-menu" aria-labelledby="moreDropDown">
                <li><a class="dropdown-item" href="#">Action</a></li>
                <li><a class="dropdown-item" href="#">Another action</a></li>
                <li><hr class="dropdown-divider" /></li>
                <li>
                  <a class="dropdown-item" href="#">Something else here</a>
                </li>
              </ul>
            </li>
          </ul>
          <ul class="navbar-nav mb-2 mb-lg-0">
            <li class="nav-item"><a href="#" class="nav-link">Sign Up</a></li>
            <li class="nav-item"><a href="#" class="nav-link">Log In</a></li>
            <li class="nav-item"><a href="#" class="nav-link">Cart</a></li>
            <li class="nav-item"><a href="#" class="nav-link">Help Center</a></li>
          </ul>
        </div>
      </div>
    </nav>

    <div class="container">
      <!--Search Area-->
      <div class="contain">
        <div class="input-group">
          <span class="input-group-text text-muted" id="search-prepend"><i class="fa fa-search"></i></span>
          <input type="text" class="form-control search-form" aria-describedby="search-prepend" placeholder="Search..." />
        </div>
      </div>
      <!--Filter Area-->
      <div class="mt-3">
          <div class="col-md-6 mx-auto">
            <nav class="nav justify-content-around">
              <a href="#" class="btn btn-secondary nav-item">All</a>
              <a href="#" class="btn btn-outline-secondary nav-item">Songs</a>
              <a href="#" class="btn btn-outline-secondary nav-item">Album</a>
              <a href="#" class="btn btn-outline-secondary nav-item">Artists</a>
              <a href="#" class="btn btn-outline-secondary nav-item">Sounds</a>
              <a href="#" class="btn btn-outline-secondary nav-item">Producer</a>
            </nav>
          </div>
          <!-- <div class="col-md-3">
            <select name="filter" id="filter" class="form-control">
              <option value="Popularity"></option>
              <option value="Popularity(Global)"></option>
              <option value="Alphabetical"></option>
              <option value="Date Added"></option>
            </select>
          </div> -->
      </div>
      <!--Songs Result-->
      <div class="mt-3">
        <div class="d-flex justify-content-between">
          <h5>Songs</h5>
          <h5 class="text-muted"><small>View All</small></h5>
        </div>
        <div>
          <div class="list-item">
            <img
              class="list-img"
              src="https://mtracks.azureedge.net/public/images/albums/260/909.jpg"
            />
              <p class="list-item-20">What a Beautiful Name</p>
              <p class="list-item-20">Hillsong Worship</p>
              <p class="list-item-20">Let there be light</p>
            <p class="list-item-20">Let there be light</p>
            <i class="fa fa-elipsis-h"></i>
          </div>
          <div class="list-item">
            <img
              class="list-img"
              src="https://mtracks.azureedge.net/public/images/albums/260/909.jpg"
            />
              <p class="list-item-20">What a Beautiful Name</p>
              <p class="list-item-20">Hillsong Worship</p>
              <p class="list-item-20">Let there be light</p>
            <p class="list-item-20">Let there be light</p>
            <i class="fa fa-elipsis-h"></i>
          </div>
          <div class="list-item">
            <img
              class="list-img"
              src="https://mtracks.azureedge.net/public/images/albums/260/909.jpg"
            />
              <p class="list-item-20">What a Beautiful Name</p>
              <p class="list-item-20">Hillsong Worship</p>
              <p class="list-item-20">Let there be light</p>
            <p class="list-item-20">Let there be light</p>
            <i class="fa fa-elipsis-h"></i>
          </div>
          <div class="list-item">
            <img
              class="list-img"
              src="https://mtracks.azureedge.net/public/images/albums/260/909.jpg"
            />
              <p class="list-item-20">What a Beautiful Name</p>
              <p class="list-item-20">Hillsong Worship</p>
              <p class="list-item-20">Let there be light</p>
            <p class="list-item-20">Let there be light</p>
            <i class="fa fa-elipsis-h"></i>
          </div>
        </div>
      </div>
      <!--Album Result-->
      <div class="mt-3">
        <div class="d-flex justify-content-between">
          <h5>Albums</h5>
          <h5 class="text-muted"><small>View All</small></h5>
        </div>
        <div class="row">
          <div class="col-md-2">
            <img
              src="https://mtracks.azureedge.net/public/images/albums/260/5020.jpg"
              alt="Album Art"
              class="img-fluid album-art"
            />
            <h6 class="album-title">
              Out Here On a Friday Where It Began<br /><small
                >Hillsong Young & Free</small
              >
            </h6>
          </div>
          <div class="col-md-2">
            <img
              src="https://mtracks.azureedge.net/public/images/albums/260/5020.jpg"
              alt="Album Art"
              class="img-fluid album-art"
            />
            <h6 class="album-title">
              Out Here On a Friday Where It Began<br /><small
                >Hillsong Young & Free</small
              >
            </h6>
          </div>
          <div class="col-md-2">
            <img
              src="https://mtracks.azureedge.net/public/images/albums/260/5020.jpg"
              alt="Album Art"
              class="img-fluid album-art"
            />
            <h6 class="album-title">
              Out Here On a Friday Where It Began<br /><small
                >Hillsong Young & Free</small
              >
            </h6>
          </div>
          <div class="col-md-2">
            <img
              src="https://mtracks.azureedge.net/public/images/albums/260/5020.jpg"
              alt="Album Art"
              class="img-fluid album-art"
            />
            <h6 class="album-title">
              Out Here On a Friday Where It Began<br /><small
                >Hillsong Young & Free</small
              >
            </h6>
          </div>
          <div class="col-md-2">
            <img
              src="https://mtracks.azureedge.net/public/images/albums/260/5020.jpg"
              alt="Album Art"
              class="img-fluid album-art"
            />
            <h6 class="album-title">
              Out Here On a Friday Where It Began<br /><small
                >Hillsong Young & Free</small
              >
            </h6>
          </div>
          <div class="col-md-2">
            <img
              src="https://mtracks.azureedge.net/public/images/albums/260/5020.jpg"
              alt="Album Art"
              class="img-fluid album-art"
            />
            <h6 class="album-title">
              Out Here On a Friday Where It Began<br /><small
                >Hillsong Young & Free</small
              >
            </h6>
          </div>
        </div>
      </div>
      <!--Artist Result-->
      <div class="mt-3">
        <div class="d-flex justify-content-between">
          <h5>Artist</h5>
          <h5 class="text-muted"><small>View All</small></h5>
        </div>
        <div class="row">
          <div class="col-md-2">
            <img src="https://mtracks.azureedge.net/public/images/artists/cover/260/5.jpg" alt="Artist cover" class="img-fluid artist-art">
            <div class="text-center">
              <h6 class="album-title">Hillsong Worship<br><small>35 Albums</small></p>
            </div>
          </div>
          <div class="col-md-2">
            <img src="https://mtracks.azureedge.net/public/images/artists/cover/260/5.jpg" alt="Artist cover" class="img-fluid artist-art">
            <div class="text-center">
              <h6 class="album-title">Hillsong Worship<br><small>35 Albums</small></p>
            </div>
          </div>
          <div class="col-md-2">
            <img src="https://mtracks.azureedge.net/public/images/artists/cover/260/5.jpg" alt="Artist cover" class="img-fluid artist-art">
            <div class="text-center">
              <h6 class="album-title">Hillsong Worship<br><small>35 Albums</small></p>
            </div>
          </div>
          <div class="col-md-2">
            <img src="https://mtracks.azureedge.net/public/images/artists/cover/260/5.jpg" alt="Artist cover" class="img-fluid artist-art">
            <div class="text-center">
              <h6 class="album-title">Hillsong Worship<br><small>35 Albums</small></p>
            </div>
          </div>
          <div class="col-md-2">
            <img src="https://mtracks.azureedge.net/public/images/artists/cover/260/5.jpg" alt="Artist cover" class="img-fluid artist-art">
            <div class="text-center">
              <h6 class="album-title">Hillsong Worship<br><small>35 Albums</small></p>
            </div>
          </div>
          <div class="col-md-2">
            <img src="https://mtracks.azureedge.net/public/images/artists/cover/260/5.jpg" alt="Artist cover" class="img-fluid artist-art">
            <div class="text-center">
              <h6 class="album-title">Hillsong Worship<br><small>35 Albums</small></p>
            </div>
          </div>
        </div>
      </div>
      <!--Sound Result-->
      <div class="mt-3">
        <div class="d-flex justify-content-between">
          <h5>Sounds</h5>
          <h5 class="text-muted"><small>View All</small></h5>
        </div>
        <div>
          <div class="list-item">
            <img
              class="list-img"
              src="https://mtracks.azureedge.net/public/images/albums/260/909.jpg"
            />
              <p>What a Beautiful Name</p>
              <p>Hillsong Worship</p>
              <p>Let there be light</p>
          </div>
          <div class="list-item">
            <img
              class="list-img"
              src="https://mtracks.azureedge.net/public/images/albums/260/909.jpg"
            />
              <p>What a Beautiful Name</p>
              <p>Hillsong Worship</p>
              <p>Let there be light</p>
          </div>
          <div class="list-item">
            <img
              class="list-img"
              src="https://mtracks.azureedge.net/public/images/albums/260/909.jpg"
            />
              <p>What a Beautiful Name</p>
              <p>Hillsong Worship</p>
              <p>Let there be light</p>
          </div>
          <div class="list-item">
            <img
              class="list-img"
              src="https://mtracks.azureedge.net/public/images/albums/260/909.jpg"
            />
              <p>What a Beautiful Name</p>
              <p>Hillsong Worship</p>
              <p>Let there be light</p>
          </div>
        </div>
      </div>
      <!--Producer Result-->
      <div class="mt-3">
        <div class="d-flex justify-content-between">
          <h5>Producers</h5>
          <h5 class="text-muted"><small>View All</small></h5>
        </div>
        <div class="row mb-5">
          <div class="col-md-2">
            <img
              src="https://mtracks.azureedge.net/public/images/albums/260/5020.jpg"
              alt="Album Art"
              class="img-fluid artist-art"
            />
            <h6 class="album-title">
              Out Here On a Friday Where It Began<br /><small
                >Hillsong Young & Free</small
              >
            </h6>
          </div>
          <div class="col-md-2">
            <img
              src="https://mtracks.azureedge.net/public/images/albums/260/5020.jpg"
              alt="Album Art"
              class="img-fluid artist-art"
            />
            <h6 class="album-title">
              Out Here On a Friday Where It Began<br /><small
                >Hillsong Young & Free</small
              >
            </h6>
          </div>
          <div class="col-md-2">
            <img
              src="https://mtracks.azureedge.net/public/images/albums/260/5020.jpg"
              alt="Album Art"
              class="img-fluid artist-art"
            />
            <h6 class="album-title">
              Out Here On a Friday Where It Began<br /><small
                >Hillsong Young & Free</small
              >
            </h6>
          </div>
        </div>
      </div>
    </div>


      <script
      src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"
      integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM"
      crossorigin="anonymous"
    ></script>
    </form>
</body>
</html>
