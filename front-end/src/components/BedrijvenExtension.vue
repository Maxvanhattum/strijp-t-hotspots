<template>
  <div class="container">
    <div class="background_bedrijvenExt">
      <img class="backgroundImage" :src="image.Strijp_locatie" />
      <div class="backgroundStripe_blue"></div>
      <div class="backgroundColor_grey"></div>
    </div>
    <div class="bedrijvenCards_overview">
      <div class="Title">
        <p
          class="back"
          @click="hasHistory() ? $router.go(-1) : $router.push('/')"
        >
          &lt;
        </p>
        <h1>
          BEDRIJVEN
          <br />BIJ DEZE HOTSPOT
        </h1>
      </div>
      <div class="Searchbar">
        <input type="text" placeholder="Search.." class="search" />
      </div>

      <div class="Bedrijven-cards">
        <ul class="Flex-container">
          <div v-for="component in bedrijven" :key="component.id">
            <BedrijvenExtCards :cardData="component" />
          </div>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import BedrijvenExtCards from "../components/BedrijvenExtOverview/BedrijvenExtCards";

export default {
  name: "BedrijvenExtension",
  components: {
    /*BedrijvenExtUl,
    BedrijvenExtLi,*/
    BedrijvenExtCards
  },
  props: {
    bedrijven: Array
  },
  data() {
    return {
      image: {
        Strijp_locatie: require("../assets/Foto strijp-t.jpg")
      }
    };
  },
  methods: {
    hasHistory() {
      return window.history.length > 2;
    }
  }
};
</script>

<style scoped>
.back {
  position: absolute;
  left: 100px;
  top: -1px;
  float: left;
  border: none;
  color: #eff1f0;
  text-align: center;
  text-decoration: none;
  font-size: 29px;
  cursor: pointer;
  background-color: #001273;
  border-radius: 100px;
  width: 50px;
  height: 50px;
}

ul {
  margin: 0;
  padding: 0;
}

.container {
  display: flex;
}

.backgroundImage {
  width: 100%;
}

.backgroundStripe_blue {
  display: block;
  width: 100%;
  height: 2vh;
  background-color: #001273;
  margin-top: -1vh;
}

.backgroundColor_grey {
  display: block;
  background-color: #eff1f0;
  height: 100vh;
  width: 100%;
  margin-top: -1vh;
}

.bedrijvenCards_overview {
  display: block;
  background-color: white;
  width: 43vw;
  margin-left: 23%;
  margin-top: 10vh;
  border-radius: 30px;
  position: absolute;
  padding-left: 6vw;
  padding-right: 5vw;
  padding-bottom: 5vh;
}

.Title h1 {
  text-align: center;
  font-size: 18pt;
  color: #001273;
  margin-top: 15px;
}

.search {
  width: 93%;
  padding: 5px;
  padding-left: 2vw;
  height: 25px;
  border-radius: 20px 20px 20px 20px;
  background-color: #f1f3f4;
  border-color: #f1f3f4;
}

.Bedrijven-cards {
  margin-top: 3vh;
}

.Flex-container {
  display: flex;
  flex-wrap: wrap;
}

@media screen and (max-width: 992px) {
  .back {
    position: absolute;
    left: 50px;
    top: -1px;
    float: left;
    border: none;
    color: #eff1f0;
    text-align: center;
    text-decoration: none;
    font-size: 23px;
    cursor: pointer;
    background-color: #001273;
    border-radius: 100px;
    width: 40px;
    height: 40px;
  }

  .bedrijvenCards_overview {
    padding-bottom: 2vh;
    width: 50vw;
  }

  .backgroundColor_grey {
    height: 90vh;
  }

  .Title h1 {
    text-align: center;
    font-size: 14pt;
  }

  .search {
    padding: 2px;
    padding-left: 2vw;
    border-radius: 20px 20px 20px 20px;
    background-color: #f1f3f4;
    border-color: #f1f3f4;
  }

  .Bedrijven-cards {
    display: flex;
    margin-top: 2vh;
    flex-wrap: wrap;
  }
}

@media screen and (max-width: 600px) {
  .back {
    position: absolute;
    left: 0px;
    top: -5px;
    float: left;
    border: none;
    color: #eff1f0;
    text-align: center;
    text-decoration: none;
    font-size: 28px;
    cursor: pointer;
    background-color: #001273;
    border-radius: 100px;
    width: 49px;
    height: 49px;
    margin-left: 3vw;
  }

  .backgroundImage {
    display: none;
  }

  .backgroundStripe_blue {
    display: none;
  }

  .backgroundColor_grey {
    display: none;
  }
  .bedrijvenCards_overview {
    background-color: white;
    width: 89vw;
    margin-left: 6vw;
    margin-right: 6vw;
    margin-top: 0vh;
    padding-left: 0vw;
    padding-right: 0vw;
  }
  .Title h1 {
    text-align: right;
    font-size: 16pt;
    color: #001273;
    margin-right: 5px;
    margin-top: 15px;
  }

  .search {
    width: 95%;
    padding: 5px;
    padding-left: 2vw;
    height: 25px;
    border-radius: 20px 20px 20px 20px;
    background-color: #f1f3f4;
    border-color: #f1f3f4;
  }

  .Bedrijven-cards {
    display: flex;
    margin-top: 3vh;
    flex-wrap: wrap;
    margin-left: 2vw;
  }
}
</style>
