<template>
  <div class="BedrijvenExtCards">
    <button class="BackgroundButton">
      <div class="CardInfo">
        <center>
          <h3 class="BedrijfNaam">{{ cardData.name }}</h3>
          <p class="BedrijfAdress">
            {{ cardData.address.streetName }} {{ cardData.address.houseNumber }}
          </p>
          <p class="BedrijfAdress">
            {{ cardData.address.zipcode }} {{ cardData.address.city }}
          </p>
          <a :href="cardData.url" class="BedrijfWebsite">Go to website</a>
        </center>
      </div>
    </button>
  </div>
</template>

<script>
export default {
  name: "BedrijvenExtCards",
  data() {
    return {
      image: {
        fontyslogo: require("../../assets/Fontys logo white-01.png")
      }
    };
  },
  props: {
    cardData: Object
  }
};
</script>

<style scoped>
.BedrijvenExtCards {
  margin-bottom: 2vh;
  margin-right: 1.3vh;
}

button.BackgroundButton {
  margin: 0px 0px 0px 0px;
}

h3 {
  color: white;
  margin-top: -1vh;
  margin-bottom: 3vh;
}

.BackgroundButton {
  display: block;
  background-color: #001273;
  height: 10vw;
  width: 10vw;
  border-radius: 20px;
  border: none;
}

.CardInfo p {
  font-size: 8pt;
  color: white;
  line-height: 70%;
}

.BedrijfNaam {
  font-weight: bold;
}

.BedrijfWebsite {
  border-radius: 20px 20px 20px 20px;
  color: white;
  border: none;
  font-size: 8pt;
  margin-bottom: 1.5vh;
}

@media screen and (max-width: 992px) {
  .BedrijvenExtCards {
    margin-bottom: 1vh;
    margin-right: 1.2vh;
  }
  .BackgroundButton {
    display: block;
    background-color: #001273;
    height: 15vw;
    width: 15vw;
    border-radius: 20px;
    border: none;
  }

  h3 {
    color: white;
    margin-bottom: 1.5vh;
    font-size: 8pt;
  }

  .CardInfo {
    text-align: center;
    margin-top: 1vh;
  }

  .CardInfo p {
    font-size: 5pt;
    color: white;
    text-align: center;
  }

  .BedrijfNaam {
    font-weight: bold;
  }

  .BedrijfWebsite {
    border-radius: 20px 20px 20px 20px;
    color: white;
    border: none;
    font-size: 6pt;
    margin-bottom: 1.5vh;
  }
}

@media screen and (max-width: 600px) {
  .BedrijvenExtCards {
    margin-bottom: 1vh;
    margin-right: 3.5vw;
  }

  .BackgroundButton {
    display: block;
    background-color: #001273;
    height: 40vw;
    width: 40vw;
    border-radius: 20px;
    border: none;
  }

  h3 {
    color: white;
    margin-bottom: 2vh;
    font-size: 10pt;
  }

  .CardInfo p {
    font-size: 7pt;
    color: white;
    line-height: 70%;
    text-align: center;
  }

  .CardInfo {
    text-align: center;
  }

  .BedrijfWebsite {
    border-radius: 20px 20px 20px 20px;
    color: white;
    border: none;
    font-size: 7pt;
    margin-bottom: 1.5vh;
  }
}
</style>
