<template>
  <div>
    <div class="bedrijvenCards_overview">
      <div class="Title">
        <h1>BEDRIJVEN<br />BIJ DEZE HOTSPOT</h1>
      </div>
      <div class="cards-container">
        <div class="bedrijven-cards">
          <div v-for="component in bedrijven.slice(0, 3)" :key="component.id">
            <BedrijvenExtCards :cardData="component" />
          </div>
        </div>
        <div class="button-container">
          <router-link
            class="more-button"
            :to="'/details/' + id + '/businesses'"
            tag="button"
            >Meer bedrijven...</router-link
          >
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import BedrijvenExtCards from "../BedrijvenExtOverview/BedrijvenExtCards";

export default {
  name: "BedrijvenExtension",
  components: {
    BedrijvenExtCards
  },
  props: {
    bedrijven: Array,
    id: Number
  }
};
</script>

<style scoped>
.button-container {
  display: flex;
  justify-content: center;
}

.more-button {
  background: #001273;
  color: #fff;
  text-decoration: none;
  font-size: 13px;
  line-height: 38px;
  border-radius: 50px;
  width: 170px;
  text-align: center;
  margin-top: 20px;
  margin-left: -15px;
}

.bedrijvenCards_overview {
  background-color: white;
  width: 100%;
  max-width: 800px;
  margin: 5vh auto;
  border-radius: 30px;
  padding: 1.5vh;
}

.bedrijven-cards {
  display: flex;
  justify-content: space-evenly;
  flex-wrap: wrap;
}

.Title h1 {
  text-align: center;
  font-size: 18pt;
  color: #001273;
  padding: 1vh 0px;
}

.Bedrijven-cards {
  display: flex;
  margin-top: 3vh;
  flex-wrap: wrap;
}

@media screen and (max-width: 992px) {
  .bedrijvenCards_overview {
    padding-bottom: 2vh;
    width: 50vw;
  }

  .Title h1 {
    text-align: center;
    font-size: 14pt;
  }

  .Bedrijven-cards {
    display: flex;
    margin-top: 2vh;
    flex-wrap: wrap;
  }
}

@media screen and (max-width: 600px) {
  .bedrijvenCards_overview {
    background-color: white;
    width: 89vw;
  }
  .Title h1 {
    text-align: center;
    font-size: 16pt;
    color: #001273;
    margin-right: 5px;
    margin-top: 15px;
  }

  .Bedrijven-cards {
    display: flex;
    margin-top: 3vh;
    flex-wrap: wrap;
  }
}
</style>
