import { useDateFormat } from "@vueuse/core"

export const makeDateNice = (d: Date) => useDateFormat(d, "YYYY-MM-DD HH:mm:ss").value.toString();