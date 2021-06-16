<template>
  <div>
    <ul class="Flex-container"></ul>
  </div>
</template>

<script>
export default {
  name: "BedrijvenExtUl"
};
</script>

<style>
.Flex-container {
  display: flex;
  margin-top: 11vh;
  justify-content: space-evenly;
  flex-wrap: wrap;
  padding-inline-start: 17px;
}

ul.Flex-container {
  list-style-type: none;
}
</style>
